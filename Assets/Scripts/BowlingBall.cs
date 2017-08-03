using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {
    
    public bool hasLaunched { get; private set; }

    private AudioSource rollingSound;
    private Rigidbody rigidBody;
    private Vector3 startingPosition;
   

	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        startingPosition = transform.position;
        Reset();
    }

    public void Launch(Vector3 velocity)
    {
        rigidBody.velocity = velocity;
        rigidBody.useGravity = true;

        hasLaunched = true;

        rollingSound = GetComponent<AudioSource>();
        rollingSound.Play();
    }

    public void Reset()
    {
        rigidBody.useGravity = false;
        hasLaunched = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = startingPosition;
    }
}
