using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public Transform pathStart;

    private Transform currentPathPoint;
    private float timeToTake;
    private float timeToTurn;
    private float totalTime;
    private float startAngle;

    private Vector3 lastStartPoint;
    private float xDistance;
    private float yDistance;
    private bool facingRightDirection;
    private float targetAngle;
    private int direction;

    private int nextChild;

	// Use this for initialization
	void Start () {
        SetUpNewPathTarget(pathStart);
        nextChild = 0;
        facingRightDirection = true;
    }
	
	// Update is called once per frame
	void Update () {
        totalTime += Time.unscaledDeltaTime;

        StateScript.States curState = GetComponent<StateScript>().GetState();

        switch (curState)
        {
            case StateScript.States.Patrolling:
                UpdatePatrol();
                break;
            case StateScript.States.Attacking:
                Debug.Log("ATTACK");

                break;

        }

      
    }

    void UpdatePatrol()
    {
        if (facingRightDirection)
        {

            float percComplete = totalTime / timeToTake;

            if (percComplete > 1.0f)
            {
                if (nextChild < pathStart.childCount)
                {
                    SetUpNewPathTarget(pathStart.GetChild(nextChild));
                    nextChild = nextChild + 1;
                }
                else
                {
                    SetUpNewPathTarget(pathStart);
                    nextChild = 0;
                }
            }
            else
            {
                Vector3 newPos;
                newPos.x = lastStartPoint.x - (xDistance * percComplete);
                newPos.y = lastStartPoint.y - (yDistance * percComplete);
                newPos.z = 0.0f;

                transform.position = newPos;
            }
        }
        else
        {


            Vector3 vectorToTarget = currentPathPoint.position - transform.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * turnSpeed);

            float result = Mathf.Abs(transform.rotation.eulerAngles.z) - Mathf.Abs(q.eulerAngles.z);
            if (Mathf.Abs(result) < 1.0f)
            {
                //transform.rotation = Quaternion.Euler(0, 0, targetAngle + 90);
                facingRightDirection = true;
                totalTime = 0.0f;
            }

        }
    }

    float WorkOutTime(Transform point)
    {
        float xDist = Mathf.Abs(transform.position.x - point.position.x);
        float yDist = Mathf.Abs(transform.position.y - point.position.y);
        float totalDistance = Mathf.Sqrt((xDist * xDist) + (yDist * yDist));

        
        return (totalDistance / speed);


    }

    float TimeToTurn(float angle)
    {
        return (0.02f * angle);
    }

    void SetUpNewPathTarget(Transform newPathPoint)
    {
        currentPathPoint = newPathPoint;
        timeToTake = WorkOutTime(currentPathPoint);
        totalTime = 0.0f;
        lastStartPoint = transform.position;
        xDistance = lastStartPoint.x - currentPathPoint.position.x;
        yDistance = lastStartPoint.y - currentPathPoint.position.y;
        targetAngle = Mathf.Atan2(yDistance, xDistance) * Mathf.Rad2Deg;
       // targetAngle -= 90;
        if (targetAngle < 0) targetAngle = 360 - (Mathf.Abs(targetAngle));
        Debug.Log(targetAngle);
        startAngle = transform.rotation.eulerAngles.z;
        //Debug.Log(startAngle);
        facingRightDirection = false;

        if (currentPathPoint.position.y > lastStartPoint.y && currentPathPoint.position.x < lastStartPoint.x)
        {
            targetAngle = 90;
        }

        if (startAngle - targetAngle > 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
            
    }
}
