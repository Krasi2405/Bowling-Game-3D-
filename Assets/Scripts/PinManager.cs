using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour {

    [SerializeField]
    public float settlingTime = 3f;


    private int pinsAtStart = 10;
    private int lastFrameStandingPinsCount;
    private float currentTime = 0;


    public int CountStanding()
    {
        int standingCount = 0;
        Pin[] pins = Pin.FindObjectsOfType<Pin>();
        foreach (Pin pin in pins)
        {
            if (pin.isStanding())
            {
                standingCount++;
            }
        }
        return standingCount;
    }


    public List<Pin> GetStandingPins()
    {
        List<Pin> pins = new List<Pin>();
        foreach (Pin pin in Pin.FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                pins.Add(pin);
            }
        }
        return pins;
    }

    public int GetNumberFallenPins()
    {
        return pinsAtStart - CountStanding();
    }
    

    // Check if pins have settled
    public bool CheckPinsHaveSettled()
    {

        int standingPinsCount = CountStanding();
        if (standingPinsCount == lastFrameStandingPinsCount)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0;
        }
        lastFrameStandingPinsCount = standingPinsCount;
        if (currentTime > settlingTime)
        {
            currentTime = 0;
            return true;
        }
        return false;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponentInParent<Pin>())
        {
            Destroy(collider.transform.parent.gameObject);
        }
    }
}
