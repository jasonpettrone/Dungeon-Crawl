using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D rigidBody;
    private bool moving;
    public float timeBetweenMove;
    public float timeToMove;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;
    private GameObject player;
    

	// Use this for initialization
	void Start () {
        
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
        rigidBody = GetComponent<Rigidbody2D>();
        moving = false;
        reloading = false;
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
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rigidBody.velocity = Vector2.zero;
            if(timeBetweenMoveCounter < 0)
            {
                moving = true;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                SceneManager.LoadScene("test_scene");
                player.SetActive(true);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           
            other.gameObject.SetActive(false);
            reloading = true;
            player = other.gameObject;
        }
    }
}
