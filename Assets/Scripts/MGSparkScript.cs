using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSparkScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        StartCoroutine(AnimEnd()); //this will run your timer
    }

    IEnumerator AnimEnd()
    {
        yield return new WaitForSeconds(0.2f); //this will wait 5 seconds
        Destroy(gameObject);
    }


}
