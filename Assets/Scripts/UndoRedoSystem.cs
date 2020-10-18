using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GED;

// Command Design Pattern - Undo/Redo
// log entry for undo/redo 
public struct LogEntry
{
    public GameObject entity; // the object

    public bool alive; // the object is active. If false, it means the object was deleted. // TODO: not implemented yet
    public bool active; // the object is active (i.e. visible) // TODO: this doesn't work since the update

    public Vector3 position; // position
    public Quaternion rotation; // rotation
    public Vector3 localScale; // scale
}

// class for the undo and redo system.
public class UndoRedoSystem : MonoBehaviour
{
    // the undo list. When an action is made, an undo entry is logged.
    // when an action occurs, it puts an item on the undo list.
    // this is treated as a stack, but is a linked list since items need to be deleted if the undo list surpasses a specific size.
    private static LinkedList<LogEntry> undoList = new LinkedList<LogEntry>();

    // a redo stack. When an item is pulled off of the undo stack, it is placed on the redo stack.
    // if something new is placed on the undo stack, then the redo stack is cleared.
    private static Stack<LogEntry> redoStack = new Stack<LogEntry>();

    // the undo limit for the undo-redo system.
    public static int undoLimit = 10; // TODO: not implemented yet

    // NOTE: the built-in undo/redo system does not allow for undoing and redoing deletions.
    // you likely aren't supposed to do that.

    // Start is called before the first frame update
    void Start()
    {
    }

    // records the object and the action comitted. (TODO: make static)
    // public static void RecordObject(Object entity, string desc)
    // {
    //     Undo.RecordObject(entity, desc);
    // }

    // registers a created object, since created objects can not be destroyed by standard undo/redo functions.
    // https://docs.unity3d.com/ScriptReference/Undo.RegisterCreatedObjectUndo.html
    // public static void RegisterCreatedObject(Object entity, string desc)
    // {
    //     Undo.RegisterCreatedObjectUndo(entity, desc);
    // }

    // records the object and its transformation.
    public static void RecordAction(GameObject entity, bool alive, bool active, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        // records the action
        LogEntry entry;
        entry.entity = entity;
        entry.alive = alive;
        entry.active = active;

        entry.position = position;
        entry.rotation = rotation;
        entry.localScale = scale;

        // undoList.AddFirst(entry);
        // 
        // // TODO: work out how to track object creation and destruction.
        // redoStack.Clear();

        RecordAction(entry);
    }

    // records an action from a log entry
    public static void RecordAction(LogEntry entry)
    {
        undoList.AddFirst(entry);

        // TODO: work out how to track object creation and destruction.
        redoStack.Clear();
    }

    // PerformUndo and PerformRedo can only undo the deletion of an object but not the creation of an object. They should not be used.
    // undos the last action.
    public static void UndoAction()
    {
        // Undo.PerformUndo();

        // if there are no actions to undo
        if (undoList.Count == 0)
            return;

        LogEntry e0; // the entry that will be undone and put on the redo stack.
        LogEntry e1; // the entry that will be at the top of the undo "stack" and will be the current action.

        e0 = undoList.First.Value; // gets the first entry
        // e1.entity = e0.entity; // gets the first entry again (this doesn't mean anything)

        // steps
        // 1 - get transformation information from object, and save it to e1's PRS variables.
        // 2 - override object transformation information with data in e0's PRS variables
        // 3 - set e0's PRS variables to the PRS variables in e1

        // swaps transform values between game object and attached Transform object.
        // e1 gets the values from the object on e0. This is the same object that's on e1.
        // e1.alive;
        e1.active = e0.entity.active;
        e1.position = e0.entity.transform.position; // copies the object's current position
        e1.rotation = e0.entity.transform.rotation; // copies the object's current rotation
        e1.localScale = e0.entity.transform.localScale; // copies the object's local scale.

        // e0's object is overriden with the values of e0's transform.
        // e0.entity.alive;
        e0.entity.SetActive(e0.active);
        e0.entity.transform.position = e0.position;
        e0.entity.transform.rotation = e0.rotation;
        e0.entity.transform.localScale = e0.localScale;

        // e0's transform gets given the values from e1's transform
        // e0.alive
        e0.active = e1.active;
        e0.position = e1.position;
        e0.rotation = e1.rotation;
        e0.localScale = e1.localScale;

        undoList.RemoveFirst(); // removes first entry in the undo list.
        redoStack.Push(e0); // puts the entry on the redo stack.
        e0.entity.GetComponent<ObjectScript>().ResetPreviousTransform(); // resets the previous transformation to current transform 
    }

    // redos the last action.
    public static void RedoAction()
    {
        // Undo.PerformRedo();

        // if there are no actions to redo
        if (redoStack.Count == 0)
            return;

        LogEntry e0; // the entry that will be redone and put on the undo "stack".
        LogEntry e1; // the entry that will be at the top of the redo "stack" and will be the current action.

        e0 = redoStack.Peek(); // gets the first entry
        e1.entity = e0.entity; // gets the first entry again
        // e1.entity = e0.entity; // gets the first entry again (this doesn't mean anything)

        // steps
        // 1 - get transformation information from object, and save it to e1's PRS variables.
        // 2 - override object transformation information with data in e0's PRS variables
        // 3 - set e0's PRS variables to the PRS variables in e1

        // swaps transform values between game object and attached Transform object.
        // e1 gets the values from the object on e0. This is the same object that's on e1.
        // e1.alive;
        e1.active = e0.entity.active;
        e1.position = e0.entity.transform.position; // copies the object's current position
        e1.rotation = e0.entity.transform.rotation; // copies the object's current rotation
        e1.localScale = e0.entity.transform.localScale; // copies the object's local scale.

        // e0's object is overriden with the values of e0's transform.
        // e0.alive;
        e0.entity.SetActive(e0.entity.active);
        e0.entity.transform.position = e0.position;
        e0.entity.transform.rotation = e0.rotation;
        e0.entity.transform.localScale = e0.localScale;

        // e0's transform gets given the values from e1's transform
        // e0.alive;
        e0.active = e1.active;
        e0.position = e1.position;
        e0.rotation = e1.rotation;
        e0.localScale = e1.localScale;

        redoStack.Pop(); // removes first entry in the undo list.
        undoList.AddFirst(e0); // puts the entry on the redo stack.
        e0.entity.GetComponent<ObjectScript>().ResetPreviousTransform(); // resets the previous transformation to current transform 
    }

    // update is called once per frame
    void Update()
    {
        // test inputs
        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     UndoAction();
        // }
        // if (Input.GetKeyDown(KeyCode.N))
        // {
        //     RedoAction();
        // }

    }
}
