using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterBall : MonoBehaviour {

    private PinSetter pinSetter;

    
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}
	

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<RollingBall>())
        {
            Debug.Log("Gutterball!");
            pinSetter.BallHasLeft();
        }
    }
}
