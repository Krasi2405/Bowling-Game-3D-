using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    [SerializeField]
    public Text standingPinsText;
    [SerializeField]
    public float settlingTime = 3f;
    [SerializeField]
    // Make it get the raise value from a pin
    public float raiseValue = 5f;
    [SerializeField]
    public GameObject pinsPrefab;

    private bool ballHasEntered = false;
    private float currentTime = 0;
    private RollingBall ball;
    private Swiper swiper;
    private ActionMaster actionMaster;
    private int pinsAtStart = 10;

    void Start()
    {
        actionMaster = GameObject.FindObjectOfType<ActionMaster>();
        swiper = GameObject.FindObjectOfType<Swiper>();
        ball = GameObject.FindObjectOfType<RollingBall>();
    }

	void Update () {

        if (ballHasEntered)
        {
            if (CheckPinsHaveSettled())
            {
                standingPinsText.text = CountStanding().ToString();
                Invoke("PinsHaveSettled", 1f);
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


    public void RaisePins()
    {
        List<Pin> pins = GetStandingPins();
        foreach (Pin pin in pins)
        {
            pin.Raise();
        }
    }

    public void LowerPins()
    {
        List<Pin> pins = GetStandingPins();
        foreach (Pin pin in pins)
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinsPrefab, pinsPrefab.transform.position + new Vector3(0, raiseValue, 0), Quaternion.identity);
    }

    // Run when pins have settled
    private void PinsHaveSettled()
    {
        Invoke("ResetBall", 5f);
        int fallenPins = GetNumberFallenPins();
        Debug.Log("Number of fallen pins: " + fallenPins);
        ActionMaster.Action action = actionMaster.Bowl(fallenPins);
        if (action == ActionMaster.Action.Tidy)
        {
            Invoke("Tidy", 2f);
            pinsAtStart = CountStanding();
        }
        else if(action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset)
        {
            Invoke("Swipe", 2f);
            pinsAtStart = 10;
        }
        else if(action == ActionMaster.Action.EndGame)
        {
            // TODO Actually do something when the game ends!
            print("Game has ended!");
        }
        
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
