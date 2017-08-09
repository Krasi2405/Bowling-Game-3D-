using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreDisplay : MonoBehaviour {

    [SerializeField]
    public Text[] rollsTexts;

    [SerializeField]
    public Text[] cumulativeStoreTexts;


    public void UpdateCumulativeScoreTexts(List<int> scoreList)
    {
        for(int i = 0; i < scoreList.Count; i++)
        {
            cumulativeStoreTexts[i].text = scoreList[i].ToString();
        }
    }


    public void UpdateRollsTexts(List<int> rollsList)
    {
        string rollsString = FormatRolls(rollsList);
        for (int i = 0; i < rollsString.Length; i++)
        {
            rollsTexts[i].text = rollsString[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rollsList)
    {
        string output = "";
        int offset = 0;
        for(int i = 0; i < rollsList.Count; i++)
        {
            int roll = rollsList[i];
            if((i + offset) % 2 == 0 && roll == 10)
            {
                output += "X";
                if(i <= 17 - offset)
                {
                    output += " ";
                }
                offset++;

            }
            else if((i + offset) % 2 == 1 && roll + rollsList[i - 1] == 10)
            {
                output += "/";
            }
            else if(roll == 0)
            {
                output += "-";
            }
            else
            {
                output += rollsList[i].ToString();
            }
        }
        return output;
    }
}
