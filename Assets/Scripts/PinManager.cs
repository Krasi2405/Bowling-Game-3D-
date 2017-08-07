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
        return GetStandingPins().Count;
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
        int fallenCount = pinsAtStart - CountStanding();
        SetStandingPinsCount();
        return fallenCount;
    }
    

    public void SetStandingPinsCount()
    {
        pinsAtStart = CountStanding();
        if (pinsAtStart == 0)
        {
            pinsAtStart = 10;
        }
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
