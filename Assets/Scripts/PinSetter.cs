using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {


    [SerializeField]
    public Text standingPinsText;

    private bool ballHasEntered = false;

	void Update () {
        if (ballHasEntered)
        {
            standingPinsText.text = CountStanding().ToString();
        }
	}

    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<RollingBall>())
        {
            ballHasEntered = true;
            standingPinsText.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.GetComponentInParent<Pin>())
        {
            Destroy(collider.transform.parent.gameObject);
            print("Pin " + collider.transform.parent.name + " has been destroyed!");
        }
    }


    public int CountStanding()
    {
        int standingCount = 0;
        Pin[] pins = Pin.FindObjectsOfType<Pin>();
        foreach(Pin pin in pins)
        {
            if(pin.isStanding())
            {
                standingCount++;
            }
        }
        return standingCount;
    }
}
