using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    [SerializeField]
    public Text standingPinsText;
    [SerializeField]
    public float settlingTime = 3f;

    private bool ballHasEntered = false;
    private bool pinsHaveSettled = false;
    private float currentTime = 0;
    private RollingBall ball;
    private Swiper swiper;

    void Start()
    {
        swiper = GameObject.FindObjectOfType<Swiper>();
        ball = GameObject.FindObjectOfType<RollingBall>();
    }

	void Update () {

        if (ballHasEntered && !pinsHaveSettled)
        {
            standingPinsText.text = CountStanding().ToString();

            if (CheckPinsHaveSettled())
            {
                PinsHaveSettled();
            }
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

    // Check if pins have settled
    public bool CheckPinsHaveSettled()
    {
        int standingPinsCount = CountStanding();
        if (standingPinsCount == int.Parse(standingPinsText.text))
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0;
        }

        if(currentTime > settlingTime)
        {
            return true;
        }
        return false;
    }

    public List<Pin> GetStandingPins()
    {
        List<Pin> pins = new List<Pin>();
        foreach (Pin pin in Pin.FindObjectsOfType<Pin>())
        {
            if(pin.isStanding())
            {
                pins.Add(pin);
            }
        }
        return pins;
    }

    public void RaisePins()
    {
        List<Pin> pins = GetStandingPins();
        foreach (Pin pin in pins)
        {
            Rigidbody pinRB = pin.gameObject.GetComponent<Rigidbody>();
            pinRB.useGravity = false;
            Vector3 pinPosition = pinRB.transform.position;
            pinPosition.y += 5;
            pinRB.transform.position = pinPosition;
        }
    }

    public void LowerPins()
    {
        List<Pin> pins = GetStandingPins();
        foreach (Pin pin in pins)
        {
            Rigidbody pinRB = pin.gameObject.GetComponent<Rigidbody>();
            pinRB.useGravity = true;
            Vector3 pinPosition = pinRB.transform.position;
            pinPosition.y -= 5;
            pinRB.transform.position = pinPosition;
        }
    }

    public void RenewPins()
    {

    }

    // Run when pins have settled
    private void PinsHaveSettled()
    {
        Invoke("ResetBall", 8f);
        Invoke("Tidy", 3f);
        pinsHaveSettled = true;
        standingPinsText.color = Color.green;
        ballHasEntered = false;
    }



    private void Tidy()
    {
        GetComponent<Animator>().SetTrigger("TidyTrigger");
    }

    private void Swipe()
    {
        GetComponent<Animator>().SetTrigger("SwipeTrigger");
    }

    private void ResetBall()
    {
        ball.Reset();
    }

    
}
