using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        pos.z = 45;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
        transform.position = pos;
        Cursor.visible = false;
	}
}
