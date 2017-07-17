using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour {

    public GameObject pinHolder;
    
    public void RaisePins()
    {
        foreach (Transform pin in pinHolder.transform)
        {
            Rigidbody pinRB = pin.GetComponent<Rigidbody>();
            pinRB.useGravity = false;
            Vector3 pinPosition = pinRB.transform.position;
            pinPosition.y += 5;
            pinRB.transform.position = pinPosition;
        }
    }

    public void LowerPins()
    {
        foreach(Transform pin in pinHolder.transform)
        {
            Rigidbody pinRB = pin.GetComponent<Rigidbody>();
            pinRB.useGravity = true;
            Vector3 pinPosition = pinRB.transform.position;
            pinPosition.y -= 5;
            pinRB.transform.position = pinPosition;
        }
    }
}
