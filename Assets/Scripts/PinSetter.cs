using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    [SerializeField]
    // TODO Make it get the raise value from a pin
    public float raiseValue = 5f;

    [SerializeField]
    public GameObject pinsPrefab;


    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    public void RaisePins()
    {
        List<Pin> pins = gameManager.GetStandingPins();
        foreach (Pin pin in pins)
        {
            pin.Raise();
        }
    }

    public void LowerPins()
    {
        List<Pin> pins = gameManager.GetStandingPins();
        foreach (Pin pin in pins)
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Getting pins called!");
        Instantiate(pinsPrefab, pinsPrefab.transform.position + new Vector3(0, raiseValue, 0), Quaternion.identity);
    }
    

    public void ExecuteAction(ActionMaster.Action action, float waitTime)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            Invoke("Tidy", waitTime);
        }
        else if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset)
        {
            Invoke("Swipe", waitTime);
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            // TODO Actually do something when the game ends!
            print("Game has ended!");
        }
    }

    private void Tidy()
    {
        GetComponent<Animator>().SetTrigger("TidyTrigger");
    }

    private void Swipe()
    {
        GetComponent<Animator>().SetTrigger("SwipeTrigger");
    }

    
}
