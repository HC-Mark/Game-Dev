using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinhead : MonoBehaviour {

    //we only need to deal with collision trigger between pin head
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Pinhead")
        {
            Debug.Log("I am in collision");
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }
}
