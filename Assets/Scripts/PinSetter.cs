using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    // Value by which to raise the pins in the y axis.
    [SerializeField]
    public float raiseValue = 5f;

    // Pins prefab to spawn when resetting
    [SerializeField]
    public GameObject pinsPrefab;


    private GameManager gameManager;
    private PinManager pinManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        pinManager = GameObject.FindObjectOfType<PinManager>();
    }


    public void RaisePins()
    {
        List<Pin> pins = pinManager.GetStandingPins();
        foreach (Pin pin in pins)
        {
            pin.Raise();
        }
    }

    public void LowerPins()
    {
        List<Pin> pins = pinManager.GetStandingPins();
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
