using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField]
    public float standingThreshhold = 10f;

    private Vector3 standingPosition;
    private bool knockedDown;

    void Start () {
        standingPosition = transform.rotation.eulerAngles;
        isStanding();
	}

    public bool isStanding()
    {
        if(knockedDown)
        {
            return false;
        }
        float tiltX = Mathf.Abs(transform.rotation.eulerAngles.x);
        float tiltZ = Mathf.Abs(transform.rotation.eulerAngles.z);
        if((tiltX > standingThreshhold && tiltX < 360 - standingThreshhold) ||
           (tiltZ > standingThreshhold && tiltZ < 360 - standingThreshhold)) {
            knockedDown = true;
            return false;
            
        }
        return true;
    }

    
}
