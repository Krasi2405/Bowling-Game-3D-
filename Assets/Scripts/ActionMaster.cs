using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster : MonoBehaviour {
    
    public enum Action { Tidy, Reset, EndTurn, EndGame};

    private int[] bowls = new int[21];
    private int currentTurn = 0;
    private bool thirdBallAwarded = false;

    public Action Bowl(int pins)
    {
        if(pins < 0 || pins > 10)
        {
            throw new System.NotSupportedException("Pins should be between 0 and 10!");
        }

        bowls[currentTurn] = pins;

        currentTurn++;

        // Specially handle the last 
        if (currentTurn >= 19)
        {
            // If strike then reset and skip to 21st turn
            if(currentTurn == 19 && pins == 10)
            {
                thirdBallAwarded = true;
                return Action.Reset;
            }
            // Game Over if no strike within last 2 turns
            else if (currentTurn == 20)
            {
                if ((!thirdBallAwarded && bowls[currentTurn - 1] + bowls[currentTurn - 2] == 10) || pins == 10)
                {
                    return Action.Reset; 
                }

                if(thirdBallAwarded)
                {
                    return Action.Tidy;
                }
                else
                {
                    return Action.EndGame;
                }
            }
            // End game every time if current turn is above 21
            else if (currentTurn >= 21)
            {
                return Action.EndGame;
            }
            // Tidy when all else fails
            else
            {
                return Action.Tidy;
            }
        }

        if(currentTurn % 2 == 1) // First frame
        {
            if (pins != 10)
            {
                return Action.Tidy;
            }
            else // Handle strike
            {
                currentTurn++;
                bowls[currentTurn] = 0;
                return Action.EndTurn;
            }
        }
        else // Second(Last Frame)
        {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }
}
