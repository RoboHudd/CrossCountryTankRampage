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

    void OnCollisionEnter2D (Collision2D collision)
    {
        EnemyMovementScript moveScript = GetComponent<EnemyMovementScript>();
        Debug.Log("Hit");
        if (moveScript != null)
        {
            moveScript.speed += 1;
            moveScript.turnSpeed += 50;
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Null script");
        }
    }
}
