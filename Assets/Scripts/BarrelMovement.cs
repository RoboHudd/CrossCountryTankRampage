using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour {

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    private HingeJoint2D hinge;

	// Use this for initialization
	void Start () {
        hinge = GetComponent<HingeJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
      //  if (hinge == null) hinge = GetComponent<HingeJoint2D>();

      //  JointMotor2D motor = hinge.motor;

        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        angle -= 90;
        if (angle < 0) angle = 360 - (Mathf.Abs(angle));
      //  Debug.Log("angle: " + angle);
      //  Debug.Log("Euler: " + transform.rotation.eulerAngles.z);

        float angleDiff = transform.rotation.eulerAngles.z - angle;


            if (angleDiff > 180)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 3));
            }
            else if (angleDiff < -180)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 3));
            }
            else
            {
                if (transform.rotation.eulerAngles.z > angle)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 3));
                }
                else if (transform.rotation.eulerAngles.z < angle)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 3));
                }
            }
        


        // motor.motorSpeed = angle;

        //  hinge.motor = motor;

    }
}
