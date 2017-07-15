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
        shotTransform.rotation = transform.rotation;
        shotTransform.position = transform.position;
        
    }
}
