using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponMovementScript : MonoBehaviour {

    public Transform target;
    public Transform shotPrefab;
    public float turnSpeed;
    public float accuracy;

    private float totalTime;
    private float cReloadTime = 3.0f;

	// Use this for initialization
	void Start () {
        totalTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
        switch (GetComponentInParent<StateScript>().GetState())
        {
            case StateScript.States.Patrolling:

                break;
            case StateScript.States.Attacking:
                totalTime += Time.unscaledDeltaTime;
                Vector3 vectorToTarget = target.position - transform.position;
                float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * turnSpeed);

                float result = Mathf.Abs(transform.rotation.eulerAngles.z) - Mathf.Abs(q.eulerAngles.z);
                if (Mathf.Abs(result) < 1.0f && totalTime >= cReloadTime)
                {
                    //transform.rotation = Quaternion.Euler(0, 0, targetAngle + 90);
                    //totalTime = 0.0f;
                    // Create a new shot
                    var shotTransform = Instantiate(shotPrefab) as Transform;


                    // Assign position, rotation etc
                    Random.InitState((int)(Time.unscaledTime * 1000));
                    shotTransform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + Random.Range(-accuracy, accuracy));
                    shotTransform.position = transform.position;

                    totalTime = 0.0f;
                }

                break;
            case StateScript.States.AlertPatrol:

                break;
        }

	}
}
