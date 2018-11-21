using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D rigidBody;
    private bool moving;
    public float timeBetweenMove;
    public float timeToMove;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    

	// Use this for initialization
	void Start () {
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
        rigidBody = GetComponent<Rigidbody2D>();
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rigidBody.velocity = moveDirection;
            if(timeToMoveCounter < 0)
            {
                moving = false;
                timeToMoveCounter = timeToMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rigidBody.velocity = Vector2.zero;
            if(timeBetweenMoveCounter < 0)
            {
                moving = true;
                timeBetweenMoveCounter = timeBetweenMove;
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
	}
}
