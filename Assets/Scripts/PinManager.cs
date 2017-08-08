using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour {

    [SerializeField]
    public float settlingTime = 3f;


    private int pinsAtStart = 10;
    private int lastFrameStandingPinsCount;
    private float currentTime = 0;


    public int GetStandingCount()
    {
        int pinCount = 0;
        foreach (Pin pin in Pin.FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                pinCount++;
            }
        }
        return pinCount;
    }

    public int GetNumberFallenPins()
    {
        int fallenCount = pinsAtStart - GetStandingCount();
        return fallenCount;
    }
    
    // Call in the end of lowering the pins since lowering exists in both tidy and swipe.
    public void SetPinsAtStartCount()
    {
        pinsAtStart = GetStandingCount();
    }

    // Check if pins have settled
    public bool CheckPinsHaveSettled()
    {

        int standingPinsCount = GetStandingCount();
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
