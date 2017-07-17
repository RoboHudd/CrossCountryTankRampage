using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour {

    public Transform[] sights;

    public enum States
    {
        Patrolling,
        Attacking,
        Watching,
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

        if (newState == States.Attacking)
        {
            for (int i = 0; i < sights.Length; i++)
            {
                sights[i].localPosition = new Vector3(sights[i].localPosition.x, 10.0f, sights[i].localPosition.z);
            }
        }
        else if (newState == States.Watching)
        {
            for (int i = 0; i < sights.Length; i++)
            {
                sights[i].localPosition = new Vector3(sights[i].localPosition.x, 8.5f, sights[i].localPosition.z);
            }
        }
        else if (newState == States.AlertPatrol)
        {
            for (int i = 0; i < sights.Length; i++)
            {
                sights[i].localPosition = new Vector3(sights[i].localPosition.x, 7.0f, sights[i].localPosition.z);
            }
            GetComponent<EnemyMovementScript>().speed = 1.5f;
            GetComponent<EnemyMovementScript>().turnSpeed = 70;
            GetComponent<EnemyMovementScript>().RedoPathPoint();
        }
    }

    void Start()
    {
        state = States.Patrolling;
    }

}
