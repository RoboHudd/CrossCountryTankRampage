using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private Rigidbody2D rigidbodyComponent;

    public float speed;

    private float inputX;
    private float inputY;

    // Use this for initialization
    void Start () {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        
        if (inputX > 0)
        {
            transform.Rotate(Vector3.forward * -2);
        }
        else if (inputX < 0)
        {
            transform.Rotate(Vector3.forward * 2);
        }

        //transform.position += Vector3.forward * Time.deltaTime;
       // transform.Translate(transform.forward, Space.World);
    }

    void FixedUpdate()
    {
        inputY = Input.GetAxisRaw("Vertical");
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        if (inputY > 0)
        {
            transform.Translate(transform.up.normalized * Time.deltaTime * speed, Space.World);
        }
        else if (inputY < 0)
        {
            transform.Translate(transform.up.normalized * Time.deltaTime * -speed, Space.World);
        }

    }
}
