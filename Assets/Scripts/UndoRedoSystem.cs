using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// class for the undo and redo system.
public class UndoRedoSystem : MonoBehaviour
{
    // log for undoing 
    struct LogEntry
    {
        public GameObject entity; // the object
        public Transform transform; // transformation of object that was applied
    }

    // the undo list. When an action is made, an undo entry is logged.
    // when an action occurs, it puts an item on the undo list.
    // this is treated as a stack, but is a linked list since items need to be deleted if the undo list surpasses a specific size.
    private static LinkedList<LogEntry> undoList;

    // a redo stack. When an item is pulled off of the undo stack, it is placed on the redo stack.
    // if something new is placed on the undo stack, then the redo stack is cleared.
    private static Stack<LogEntry> redoStack;

    // the undo limit for the undo-redo system.
    public static int undoLimit = 10;

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
    public static void RecordAction(GameObject entity, Transform tform)
    {
        LogEntry entry;
        entry.entity = entity;
        entry.transform = tform;

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
        e1 = undoList.First.Value; // gets the first entry again
        e1.transform = e0.entity.transform; // saves the object's current transform

        // swaps transform values between game object and attached Transform object.
        // e1 gets the values from the object on e0. This is the same object that's on e1.
        e1.transform.position = e0.entity.transform.position;
        e1.transform.rotation = e0.entity.transform.rotation;
        e1.transform.localScale = e0.entity.transform.localScale;

        // e0's object is overriden with the values of e0's transform.
        e0.entity.transform.position = e0.transform.position;
        e0.entity.transform.rotation = e0.transform.rotation;
        e0.entity.transform.localScale = e0.transform.localScale;

        // e0's transform gets given the values from e1's transform
        e0.transform.position = e1.transform.position;
        e0.transform.rotation = e1.transform.rotation;
        e0.transform.localScale = e1.transform.localScale;

        undoList.RemoveFirst(); // removes first entry in the undo list.
        redoStack.Push(e0); // puts the entry on the redo stack.

        // e1 = undoList.First.Value; // gets new entry, which is now the current entry.

        // maybe track the difference in one transformation to the next.
        //
        // e0.entity.transform.position = e1.entity.transform.position;
        // e0.entity.transform.localScale = e1.entity.transform.localScale;
        // e0.entity.transform.rotation = e1.entity.transform.rotation;
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
        e1 = redoStack.Peek(); // gets the first entry again
        e1.transform = e0.entity.transform; // saves the object's current transform

        // swaps transform values between game object and attached Transform object.
        // e1 gets the values from the object on e0. This is the same object that's on e1.
        e1.transform.position = e0.entity.transform.position;
        e1.transform.rotation = e0.entity.transform.rotation;
        e1.transform.localScale = e0.entity.transform.localScale;

        // e0's object is overriden with the values of e0's transform.
        e0.entity.transform.position = e0.transform.position;
        e0.entity.transform.rotation = e0.transform.rotation;
        e0.entity.transform.localScale = e0.transform.localScale;

        // e0's transform gets given the values from e1's transform
        e0.transform.position = e1.transform.position;
        e0.transform.rotation = e1.transform.rotation;
        e0.transform.localScale = e1.transform.localScale;

        redoStack.Pop(); // removes first entry in the undo list.
        undoList.AddFirst(e0); // puts the entry on the redo stack.
    }

    // Update is called once per frame
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
