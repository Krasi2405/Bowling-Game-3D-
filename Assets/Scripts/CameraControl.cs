using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Vector3 offset;
    public GameObject toFollow;
    public float stopPositionX = 95f;
	
	void Update () {
        if (toFollow.transform.position.x <= stopPositionX)
        {
            transform.position = offset + toFollow.transform.position;
        }
        else
        {
            this.enabled = false;
        }
	}
}
