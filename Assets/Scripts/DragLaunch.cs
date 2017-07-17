using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(RollingBall))]
public class DragLaunch : MonoBehaviour {

    [SerializeField]
    public float coefficient = 25f;
    [SerializeField]
    public float nudgeLimit = 30f;

    private RollingBall ball;
    private Vector3 start;
    private Vector3 end;
    private float time;

	void Start () {
        ball = GetComponent<RollingBall>();
	}
	

    public void DragStart()
    {
        if (!ball.hasLaunched)
        {
            start = Input.mousePosition;
            time = Time.time;
        }
    }

    public void DragEnd()
    {
        if (!ball.hasLaunched)
        {
            end = Input.mousePosition;
            time = Time.time - time;
            // Launch translated due to only 2D touch input panel.
            Vector3 launchVelocity = new Vector3(end.y - start.y, 0, -(end.x - start.x));
            ball.Launch(launchVelocity / coefficient / time);
        }
    }

    public void MoveStart(float ammount)
    {
        if (!ball.hasLaunched)
        {
            ball.transform.Translate(new Vector3(0, 0, ammount));
        }
    }
}
