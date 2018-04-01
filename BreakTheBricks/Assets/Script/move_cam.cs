using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_cam : MonoBehaviour {
    public float speed = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hori, verti, 0) * Time.deltaTime * speed); // we change the attached object by detecting we press left or right key(change will go to -1 or 1)
        //new Vector3 I guess represents for 3 axis.
        //only change x-axis now
        //Time.deltaTime means we let object move change/sec
	}
}
