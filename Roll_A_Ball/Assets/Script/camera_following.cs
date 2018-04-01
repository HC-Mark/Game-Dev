using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_following : MonoBehaviour {
    public Transform player_transform;

    // a private object to keep track of the offset between ball and camera -- it is a vector
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        //initialize in Start()
        //transform.position is the position of current object
        offset = transform.position - player_transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = offset + player_transform.position;
	}
}
