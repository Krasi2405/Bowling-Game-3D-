using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMaster {

    public static List<int> ScoreFrames(List<int> rollsList)
    {

        List<int> frameList = new List<int>();

        // Frame index points to the first bowl from the turn.
        for(int i = 0; i < rollsList.Count; i += 2)
        {
            // Handle strike
            if (rollsList[i] == 10)
            {
                if (i + 2 < rollsList.Count)
                {
                    frameList.Add(10 + rollsList[i + 1] + rollsList[i + 2]);
                    i -= 1;
                }
            }
            // Handle spare
            else if (i + 1 < rollsList.Count && rollsList[i] + rollsList[i + 1] == 10)
            {
                if (i + 2 < rollsList.Count)
                {
                    frameList.Add(10 + rollsList[i + 2]);
                }
            }
            // Normal frame handling
            else
            {
                if (i + 1 < rollsList.Count)
                {
                    frameList.Add(rollsList[i] + rollsList[i + 1]);
                }
            }
        }

        // Destroy the last 11th frame if it got in the frame list.
        if (frameList.Count == 11)
        {
            frameList.RemoveAt(10);
        }

        return frameList;
    }

    public static List<int> ScoreCumulative(List<int> rollsList)
    {
        List<int> scoreList = new List<int>();
        int total = 0;
        foreach(int roll in ScoreFrames(rollsList))
        {
            total += roll;
            scoreList.Add(total);
        }
        return scoreList;
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
