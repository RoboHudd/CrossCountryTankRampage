using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollision : MonoBehaviour {

    private int health = 20;

    public Sprite pre1, pre2, pre3, post1, post2, post3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        BulletBehaviour shot = collision.gameObject.GetComponent<BulletBehaviour>();

        if (shot != null)
        {
            Damage(10);
        }

    }

    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                if (renderer.sprite == pre1)
                {
                    renderer.sprite = post1;
                }
                else if (renderer.sprite == pre2)
                {
                    renderer.sprite = post2;
                }
                else if (renderer.sprite == pre3)
                {
                    renderer.sprite = post3;
                }
                Destroy(GetComponent<BoxCollider2D>());
            }
        }
    }
}
