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
        if (collider.gameObject.GetComponent<RollingBall>())
        {
            Debug.Log("Gutterball!");
            gameManager.BallHasLeft();
        }
    }
}
