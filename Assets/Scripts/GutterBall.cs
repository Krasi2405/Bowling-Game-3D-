using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterBall : MonoBehaviour {

    private GameManager gameManager;

    
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<BowlingBall>())
        {
            Debug.Log("Ball has left the box!");
            gameManager.BallHasLeft();
        }
    }
}
