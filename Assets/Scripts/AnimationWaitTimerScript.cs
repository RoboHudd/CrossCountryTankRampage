using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWaitTimerScript : MonoBehaviour {

    public float waitTimer = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(AnimEnd()); //this will run your timer
    }

    IEnumerator AnimEnd()
    {
        yield return new WaitForSeconds(waitTimer);
        Destroy(gameObject);
    }


}
