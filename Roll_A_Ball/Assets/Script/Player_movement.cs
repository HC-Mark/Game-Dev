using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour
{
    private Rigidbody rd;
    public float force = 5; //able to get in insepctor panel
    private int score = 0;
    private string score_message = "Current score is: ";
    //make UI
    public Text score_board;
    public GameObject winText;

    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        score_board.text = score_message + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //directly give a force on ball
        float x_mov = Input.GetAxis("Horizontal") * force; // value between -1 and 1, if we push d, it is 1, a it is -1
        float z_mov = Input.GetAxis("Vertical") * force; //value between -1 and 1
        rd.AddForce(new Vector3(x_mov, 0, z_mov));
        if (score == 12) {
            winText.SetActive(true);
        }
    }
    
    //use collision to detect food
    void OnCollisionEnter(Collision collision)
    {
        //first we need to use collision to get the tag (not name) of gameobject
        //after collision, we will have the collider of the object we collide on
        //print(collision.collider.name);
        if (collision.collider.tag == "Food")
        {
            print(collision.collider.name);
            Destroy(collision.collider.gameObject); // destroy the object binded with collider
        }
    }

    //use triggering detect
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            score++;
            score_board.text = score_message + score.ToString();
            Destroy(other.gameObject);
        }
    }
}
