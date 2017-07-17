using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour {

    public bool hasLaunched { get; private set; }

    private AudioSource rollingSound;
    private Rigidbody rigidBody;
    

	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        hasLaunched = false;
    }

    public void Launch(Vector3 velocity)
    {
        rigidBody.velocity = velocity;
        rigidBody.useGravity = true;

        hasLaunched = true;

        rollingSound = GetComponent<AudioSource>();
        rollingSound.Play();
    }
}
