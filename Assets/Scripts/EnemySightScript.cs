using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D collider)
    {
        EnemyMovementScript moveScript = GetComponent<EnemyMovementScript>();
        Debug.Log("Hit");
        if (moveScript != null)
        {
            Debug.Log("Success");
            GetComponent<StateScript>().ChangeState(StateScript.States.Attacking);
            
        }
        else
        {
            Debug.Log("Null script");
        }
    }
}
