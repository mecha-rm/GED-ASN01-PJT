using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// class for the undo and redo system.
public class UndoRedoSystem : MonoBehaviour
{
    // NOTE: this does not allow for undoing and redoing deletions

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // This can undo the deletion of an object but not the creation of an object

    // undos the last action.
    public void UndoAction()
    {
        Undo.PerformUndo();
    }

    // redos the last action.
    public void RedoAction()
    {
        Undo.PerformRedo();
    }

    // records the object and the action comitted. (TODO: make static)
    public static void RecordObject(Object entity, string desc)
    {
        Undo.RecordObject(entity, desc);
    }

    // registers a created object, since created objects can not be destroyed by standard undo/redo functions.
    // https://docs.unity3d.com/ScriptReference/Undo.RegisterCreatedObjectUndo.html
    public static void RegisterCreatedObject(Object entity, string desc)
    {
        Undo.RegisterCreatedObjectUndo(entity, desc);
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
