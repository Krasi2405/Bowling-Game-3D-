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
        for (int i = 0; i < rollsList.Count; i++)
        {
            rollsTexts[i].text =rollsList[i].ToString();
        }
    }
}
