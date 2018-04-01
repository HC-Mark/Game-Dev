using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1, 0), Space.World); // rotate around the world access -- how to rotate faster?
	}

}
