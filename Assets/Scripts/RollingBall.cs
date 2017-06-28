using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour {

    public Vector3 startVelocity;

    private AudioSource rollingSound;
    private Rigidbody rigidBody;
    

	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rollingSound = GetComponent<AudioSource>();
        Launch();
    }
	
	void Update () {
        
    }

    void Launch()
    {
        rigidBody.velocity = startVelocity;
        rollingSound.Play();
    }
}
