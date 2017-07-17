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

    private float watchOffset;
    private float alertOffset;


	// Use this for initialization
	void Start () {
        totalTime = 0.0f;
        watchOffset = 20.0f;
        alertOffset = 10.0f;
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

                if (AreAnglesClose(transform.rotation.eulerAngles.z, q.eulerAngles.z) && totalTime >= cReloadTime)
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
                Quaternion qe = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, alertOffset);
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, qe, Time.deltaTime * turnSpeed / 5.0f);


                if (AreAnglesClose(transform.localRotation.eulerAngles.z, qe.eulerAngles.z))
                {
                    //transform.rotation = Quaternion.Euler(0, 0, targetAngle + 90);
                    alertOffset = -alertOffset;
                    totalTime = 0.0f;
                }
                break;
            case StateScript.States.Watching:
                Quaternion qu = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, watchOffset);
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, qu, Time.deltaTime * turnSpeed / 5.0f);

                if (AreAnglesClose(transform.localRotation.eulerAngles.z, qu.eulerAngles.z))
                {
                    //transform.rotation = Quaternion.Euler(0, 0, targetAngle + 90);
                    watchOffset = -watchOffset;
                    totalTime = 0.0f;
                }
                break;
        }



	}

    bool AreAnglesClose(float angle1, float angle2)
    {
        float result1 = Mathf.Abs(angle1) - Mathf.Abs(angle2);
        if (Mathf.Abs(result1) < 1.0f)
        {
            return true;
        }
        return false;
    }
}
