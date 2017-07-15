using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunScript : MonoBehaviour {

    public LayerMask layerMask;
    private float shotCooldown;
    private const float cooldownLimit = 0.2f;
    public float accuracyOffset = 0.015f;


    public Transform mgShotPrefab;
    // Use this for initialization
    void Start () {
		
	}
	
    void Fire()
    {
        Vector3 direction = transform.right;
        Random.InitState((int)(Time.unscaledTime * 1000));
        direction.x += Random.Range(-accuracyOffset, accuracyOffset);
        Random.InitState((int)(Time.unscaledTime * 2000));
        direction.y += Random.Range(-accuracyOffset, accuracyOffset);
        Debug.Log(direction);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 50.0f, layerMask);

        if (hit)
        {
            BuildingCollision shot = hit.collider.GetComponent<BuildingCollision>();

            Debug.Log("T Hit");
            if (shot != null)
            {
                shot.Damage(2);
                Debug.Log("M Hit");


                var shotTransform = Instantiate(mgShotPrefab) as Transform;
                shotTransform.position = hit.point;
                
                
                
            }
        }
    }

	// Update is called once per frame
	void Update () {
        shotCooldown -= Time.deltaTime;

        float fireInput = Input.GetAxisRaw("Fire2");

        if (fireInput > 0)
        {
            if (shotCooldown < 0.0f)
            {
                Fire();
                shotCooldown = cooldownLimit;
            }
        }

    }
}
