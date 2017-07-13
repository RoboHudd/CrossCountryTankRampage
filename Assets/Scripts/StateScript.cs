using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour {

   public enum States
    {
        Patrolling,
        Attacking,
        AlertPatrol
    }

    public States state;

    public States GetState()
    {
        return state;
    }

    public void ChangeState(States newState)
    {
        state = newState;
    }

    void Start()
    {
        state = States.Patrolling;
    }

}
