using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // include the text component
using UnityEngine.SceneManagement; //control scenes

public class GameManager : MonoBehaviour {
    //use code to get access to startpoint
    private Transform startPoint;
    private Transform spawnPoint;
    private PinControl currentPin; //get the access to sript PinControl
    //flag of game over
    private bool isGameOver = false;
    private int show_score = 0;
    public Text scoreText;
    public GameObject pinPrefab;
    private Camera mainC;
    public int change_rate = 4;
    // Use this for initialization
    void Start () {
        startPoint = GameObject.Find("StartPoint").transform; //find in the gameobject list
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        mainC = Camera.main;
        SpawnPin();
	}

    private void Update()
    {
        //no more new pin
        if (isGameOver) return;
        if (Input.GetMouseButtonDown(0)) {
            currentPin.Shooting();
        }
        if (currentPin.pinned)
        {
            show_score++;
            scoreText.text = show_score.ToString();
            if (show_score % 10 == 0 && show_score > 0)
                Modify_ball_spin(show_score);
            SpawnPin(); //so we update the currentPin, the click won't affect the previous pin
        }

    }
    //create pin
    void SpawnPin() {
        currentPin = GameObject.Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<PinControl>(); //the three parameters are object, location and rotation
    }

    public void GameOver() {
        //we need to have a flag to avoid multiple times game over
        if (isGameOver) return;
        //stop the spining of ball
        GameObject.Find("Circle").GetComponent <BallRotation>().speed = 0;
        StartCoroutine(GameOverAni());
        isGameOver = true;
    }

    IEnumerator GameOverAni() {
        while (true) {
            mainC.backgroundColor = Color.Lerp(mainC.backgroundColor, Color.red, change_rate * Time.deltaTime);
            mainC.orthographicSize = Mathf.Lerp(mainC.orthographicSize, 4, change_rate * Time.deltaTime);
            if (Math.Abs(mainC.orthographicSize - 4) <= 0.05f)
                break;
            yield return 0;
        }
        yield return new WaitForSeconds((float)0.5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*
         * try to let user to decide when to restart, but not work
        while (true)
        {
            Debug.Log("waiting user to respond\n");
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //revive the main scene after user click mouse
                yield return 0;
            }
        }
        */
    }

    private void Modify_ball_spin(int score) {
        GameObject.Find("Circle").GetComponent<BallRotation>().speed += score * change_rate;
    }
}
