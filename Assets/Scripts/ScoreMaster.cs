using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMaster {

    private static List<int> ScoreFrames(List<int> rollsList)
    {

        List<int> frameList = new List<int>();
        int[] rollsArray = rollsList.ToArray();
        int currentFrame = 0;
        for(int i = 0; i < rollsArray.Length; i++)
        {
            int score = 0;
            if (currentFrame <= 17)
            {
                // Handle strike
                if (currentFrame % 2 == 0 && rollsArray[i] == 10)
                {
                    if (i + 2 < rollsArray.Length)
                    {
                        score += rollsArray[i + 1] + rollsArray[i + 2];
                    }
                    currentFrame++;
                }
                // Handle spare
                else if (currentFrame % 2 == 1 && rollsArray[i - 1] + rollsArray[i] == 10)
                {
                    if (i + 1 < rollsArray.Length)
                    {
                        score += rollsArray[i + 1];
                    }
                }
            }
            score += rollsArray[i];
            currentFrame++;
            frameList.Add(score);
        }
        return frameList;
    }

    public static int GetTotalScore(List<int> rolls)
    {
        int score = 0;

        List<int> frameList = ScoreFrames(rolls);
        foreach(int frameScore in frameList)
        {
            score += frameScore;
        }

        return score;
    }
}
