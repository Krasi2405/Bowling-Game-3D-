﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    public Text standingPinsText;
    
    
    private bool ballHasLeftBox = false;
    private BowlingBall ball;
    private ActionMaster actionMaster;
    private PinManager pinManager;
    private PinSetter pinSetter;
    private List<int> pinList;

    // Use this for initialization
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        actionMaster = GameObject.FindObjectOfType<ActionMaster>();
        ball = GameObject.FindObjectOfType<BowlingBall>();
        pinManager = GameObject.FindObjectOfType<PinManager>();
        pinList = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballHasLeftBox)
        {
            UpdateCountUIDisplay();
            if (pinManager.CheckPinsHaveSettled())
            {
                ballHasLeftBox = false;
                Invoke("PinsHaveSettled", 1f);
            }
        }
    }

    private void ResetBall()
    {
        ball.Reset();
    }

    private void UpdateCountUIDisplay()
    {
        standingPinsText.text = pinManager.CountStanding().ToString();
    }

    public void BallHasLeft()
    {
        ballHasLeftBox = true;
        standingPinsText.color = Color.red;
    }


    // Run when pins have settled
    private void PinsHaveSettled()
    {
        Invoke("ResetBall", 5f);
        Invoke("UpdateCountUIDisplay", 5f);
        standingPinsText.color = Color.black;

        int fallenPins = pinManager.GetNumberFallenPins();
        pinList.Add(fallenPins);

        ActionMaster.Action action = ActionMaster.GetAction(pinList);
        Debug.Log("Number of fallen pins: " + fallenPins);
        Debug.Log("Action: " + action);
        pinSetter.ExecuteAction(action, 3f);
        

        ballHasLeftBox = false;
        standingPinsText.color = Color.black;
    }


    public List<Pin> GetStandingPins()
    {
        return pinManager.GetStandingPins();
    }

}
