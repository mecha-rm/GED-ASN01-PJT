using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// allows for an entity to have different states
public class StateMachine : MonoBehaviour
{
    // the state number and the names used to identifiy a given number.
    // the names are case sensitive
    public int state = 0;
    public List<string> stateNames = new List<string>();

    // a list of state observers. When the state is changed, these state observers will be notified.
    public List<StateObserver> observers;

    // Start is called before the first frame update
    void Start()
    {
        // if the state is negative
        if (state < 0)
            state = 0;
    }

    // gets the state number
    public int GetStateNumber()
    {
        return state;
    }

    // gets the state identifier
    public string GetStateName()
    {
        // returns the state name
        if(stateNames.Count != 0 && state >= 0 && state < stateNames.Count)
        {
            return stateNames[state]; // state name
        }
        else 
        {
            return ""; // empty
        }
    }

    // sets the state via its numerical value (cannot be set to -1)
    // state will not change if integer identifier is invalid
    public void SetState(int newState)
    {
        if (newState >= 0)
        {
            state = newState;
            NotifyObservers();
        }
    }

    // sets a new state based on the provided string
    // state will not change if string identifier is invalid
    public void SetState(string newState)
    {
        // list.findIndex
        int index = -1;

        // finds the state name
        for(int i = 0; i < stateNames.Count; i++)
        {
            // the new state has been found
            if(stateNames[i] == newState)
            {
                index = i;
                break;
            }    
        }

        // the state is not set to -1.
        if (index != -1)
        {
            state = index;
            NotifyObservers();
            
        }
    }

    // called when the state is changed.
    private void NotifyObservers()
    {
        // called when the state changes
        foreach (StateObserver observer in observers)
            observer.OnStateChange();
    }

    // adds a new state. Do note that this does NOT allow for states of teh same name to be added, though it is case sensitive.
    // if two states of the same name are added, only the first instance of that state will ever be acknowledged.
    public void AddState(string newState)
    {
        // goes through each state name
        foreach(string stateName in stateNames)
        {
            // if the state name has already been used.
            if (stateName == newState)
                return;
        }

        stateNames.Add(newState);
    }

    // attaches an observer
    public void AttachObserver(StateObserver observer)
    {
        // adds an observer and sets its 'subject' to this.
        observers.Add(observer);
        observer.subject = this;
    }

    // detaches an observer
    public void DetachObserver(StateObserver observer)
    {
        // removes the observer and sets 'subject' to null.
        observers.Remove(observer);
        observer.subject = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
