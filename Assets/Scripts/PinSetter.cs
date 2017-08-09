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


    public void RaisePins()
    {
        foreach (Pin pin in Pin.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in Pin.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Getting pins called!");
        Instantiate(pinsPrefab, pinsPrefab.transform.position + new Vector3(0, raiseValue, 0), Quaternion.identity);
    }
    

    public void ExecuteAction(ActionMasterOld.Action action, float waitTime)
    {
        if (action == ActionMasterOld.Action.Tidy)
        {
            Invoke("Tidy", waitTime);
        }
        else if (action == ActionMasterOld.Action.EndTurn || action == ActionMasterOld.Action.Reset)
        {
            Invoke("Swipe", waitTime);
        }
        else if (action == ActionMasterOld.Action.EndGame)
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
