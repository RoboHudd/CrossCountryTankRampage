using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightScript : MonoBehaviour {

    public LayerMask layerMask;

    public Transform sight1, sight2, sight3, sight4, sight5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit1 = Physics2D.Linecast(transform.position, sight1.position, layerMask);
        RaycastHit2D hit2 = Physics2D.Linecast(transform.position, sight2.position, layerMask);
        RaycastHit2D hit3 = Physics2D.Linecast(transform.position, sight3.position, layerMask);
        RaycastHit2D hit4 = Physics2D.Linecast(transform.position, sight4.position, layerMask);
        RaycastHit2D hit5 = Physics2D.Linecast(transform.position, sight5.position, layerMask);

        RaycastHit2D[] hits = { hit1, hit2, hit3, hit4, hit5 };

        for (int i = 0; i < hits.Length; i++)
        {

            if (hits[i])
            {
                if (hits[i].collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                   
                    GetComponentInParent<StateScript>().ChangeState(StateScript.States.Attacking);
                    break;
                }
            }
        }
       
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        GetComponentInParent<StateScript>().ChangeState(StateScript.States.Attacking);
    }


}
