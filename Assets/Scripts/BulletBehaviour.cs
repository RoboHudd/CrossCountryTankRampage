﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    private float bulletSpeed = 20.0f;
    public Transform explosion;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        transform.Translate(transform.up.normalized * Time.deltaTime * bulletSpeed, Space.World);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        var shotTransform = Instantiate(explosion) as Transform;
        shotTransform.position = transform.position;
        shotTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        HealthScript collider = collision.gameObject.GetComponent<HealthScript>();

        if (collider != null)
        {
            collider.Damage(11);
        }
    }

}
