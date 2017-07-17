using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float health;
    public Transform deathAnim;
    public Vector3 deathAnimScale;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            var shotTransform = Instantiate(deathAnim) as Transform;
            shotTransform.position = transform.position;
            shotTransform.localScale = deathAnimScale;
            Destroy(gameObject);
        }
    }
}
