using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// observes the state of an entity
public abstract class StateObserver : MonoBehaviour
{
    // the subject being observed
    public StateMachine subject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // gets the subject this observer is observing
    public StateMachine GetSubject()
    {
        return subject;
    }

    // sets the subject of the observer
    public void SetSubject(StateMachine newSubject)
    {
        // detaches observer from current subject
        if (subject != null)
            subject.DetachObserver(this);

        // attaches this to new subject. This sets the value of 'subject'.
        newSubject.AttachObserver(this);
    }

    // called when the state changes. Called by subject object.
    public abstract void OnStateChange();

    // Update is called once per frame
    void Update()
    {
        
    }
}
