using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) { 
            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for click mouse action 
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, Ball Launched");

                Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
                hasStarted = true;
                myRigidbody.velocity = new Vector2(2f, 10f);

            }
        }
    }
}
