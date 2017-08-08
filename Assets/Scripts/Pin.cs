using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField]
    public float standingThreshhold = 10f;
    [SerializeField]
    public float raiseValue = 5f;
    private bool knockedDown;

    void Start () {
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

    public void Raise()
    {
        Rigidbody pinRB = gameObject.GetComponent<Rigidbody>();
        transform.Translate(new Vector3(0, raiseValue, 0), Space.World);
        pinRB.useGravity = false;
        pinRB.velocity = Vector3.zero;
        pinRB.angularVelocity = Vector3.zero;
        pinRB.Sleep();
        transform.rotation = Quaternion.identity;
    }

    public void RaiseIfStanding()
    {
        if(isStanding())
        {
            Raise();
        }
    }

    public void Lower()
    {
        Rigidbody pinRB = gameObject.GetComponent<Rigidbody>();
        pinRB.useGravity = true;
        transform.Translate(new Vector3(0, -raiseValue, 0), Space.World);
    }

    
}
