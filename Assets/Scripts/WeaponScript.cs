using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Transform shotPrefab;

    private float shotCooldown;
    private const float cooldownLimit = 1.0f;

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    // Use this for initialization
    void Start () {
        shotCooldown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        shotCooldown -= Time.deltaTime;

        float fireInput = Input.GetAxisRaw("Fire1");

        if (fireInput > 0)
        {
            if (shotCooldown < 0.0f)
            {
                Fire();
                shotCooldown = cooldownLimit;
            }
            
        }
	}

    void Fire()
    {
        // Create a new shot
        var shotTransform = Instantiate(shotPrefab) as Transform;


        // Assign position, rotation etc
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        shotTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        shotTransform.position = transform.position;
        
    }
}
