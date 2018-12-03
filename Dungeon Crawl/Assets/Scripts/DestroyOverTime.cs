using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
    public float timeToDestory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeToDestory -= Time.deltaTime;
        if(timeToDestory <= 0)
        {
            Destroy (gameObject);
        }
		
	}
}
