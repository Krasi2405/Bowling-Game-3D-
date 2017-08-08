using System.Collections;
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
    private ScoreDisplay scoreDisplay;

    // Use this for initialization
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        actionMaster = GameObject.FindObjectOfType<ActionMaster>();
        ball = GameObject.FindObjectOfType<BowlingBall>();
        pinManager = GameObject.FindObjectOfType<PinManager>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
        pinList = new List<int>();

        scoreDisplay.UpdateCumulativeScoreTexts(pinList);
        scoreDisplay.UpdateRollsTexts(pinList);
    }

    // Update is called once per frame
    void Update()
    {
        if (ballHasLeftBox)
        {
            UpdatePinCountUIDisplay();
            if (pinManager.CheckPinsHaveSettled())
            {
                ballHasLeftBox = false;
                PinsHaveSettled();
            }
        }
    }


    private void ResetBall()
    {
        ball.Reset();
    }


    private void UpdatePinCountUIDisplay()
    {
        standingPinsText.text = pinManager.GetStandingCount().ToString();
    }


    public void BallHasLeft()
    {
        ballHasLeftBox = true;
        standingPinsText.color = Color.red;
    }


    // Run when pins have settled
    private void PinsHaveSettled()
    {
        Invoke("ResetBall", 4f);
        Invoke("UpdatePinCountUIDisplay", 4f);
        standingPinsText.color = Color.black;

        int fallenPins = pinManager.GetNumberFallenPins();

        pinList.Add(fallenPins);

        ActionMaster.Action action = ActionMaster.GetAction(pinList);
        Debug.Log("Number of fallen pins: " + fallenPins);
        Debug.Log("Action: " + action);
        pinSetter.ExecuteAction(action, 1f);

        scoreDisplay.UpdateCumulativeScoreTexts(ScoreMaster.ScoreCumulative(pinList));
        scoreDisplay.UpdateRollsTexts(pinList);

        ballHasLeftBox = false;
        standingPinsText.color = Color.black;
    }

}
