using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinControl : MonoBehaviour {
    //pin need to first move to start point then player shoots it
    public float speed = 15;
    private bool isShot = false;
    private bool isStart = false;

    private Transform startPoint;
    private Transform circle;
    Vector3 targetPos;
    public bool pinned = false;
	// Use this for initialization
	void Start () {
        startPoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.Find("Circle").transform;
        targetPos = circle.position;
        targetPos.y = targetPos.y - 2.235f; //hard code by calculating from Unity interface
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShot)
        {
            //first we check whether the pin has got to startpoint
            if (!isStart)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startPoint.position) < 0.01f)
                {
                    isStart = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.05f) {
                transform.position = targetPos;
                transform.parent = circle;
                pinned = true;
                isShot = false;
            }
        }
	}

    public void Shooting() {
        isShot = true;
        isStart = true;
    }
}
