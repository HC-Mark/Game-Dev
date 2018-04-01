using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    public float speed = 20;
	// Use this for initialization
	void Start () {
        Debug.Log("Hello Unity");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            //getmousebuttondown(0) is for detecting the press of left button
            GameObject b1 = GameObject.Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody rgb = b1.GetComponent<Rigidbody>(); //here we use function to get the rigid body component of object
            rgb.velocity = transform.forward * speed; //here the transform means the object we attach our script to, forward depends on its direction
        }
	}
}
