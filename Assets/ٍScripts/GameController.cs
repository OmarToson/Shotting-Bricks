using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //for text (score)

public class GameController : MonoBehaviour {

    //we want to make random astroit(hazard)
    public GameObject hazard;    //for astroid
    public Vector3 spawnValues;   //to show x,y,z for the position which we want to show astroid on it   //x=6  y=0  z=16

    public int hazardCount;   //to write number of hazards --> 10
    public float spawnWait;   //for wait between each hazard
    public float waveWait;   //for wait between each for loop(between every 10 hazards)
    public float startWait;   //for wait before hazerd felt down(ready player)

    //for score
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text CopyRight;

    private int Score;   //for no access from inspector
    private bool restart;
    private bool gameOver;

    void Start () {
        Score = 0;   //firstly set score 0
        restart = false;
        gameOver = false;

        restartText.text = "";
        gameOverText.text = "";

        UpdateScore();  //call function to show in screen

        CopyRight.text = "Made By : Omar Khater";

        StartCoroutine(SpawnWaves());   //because yield
	}

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))   
            {
                Application.LoadLevel (Application.loadedLevel);  //to reload game
            }
        }   
    }

    IEnumerator SpawnWaves()   //not void because yield
    {
        yield return new WaitForSeconds(startWait);
        while (true)    //to make all time not hazed count only
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //the position is 0 in y and 16 in z and random value between -6 and 6 in x
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;       //for the rotation of astroid
                Instantiate(hazard, spawnPosition, spawnRotation);    //put astroid in the position ... and in the rotation ...

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)      //if game over true show restart
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;       //stop no astroit felt down after this cycle or after 10 hazard
            }

        }
    }

    public void AddScore(int newScoreValue)    // func take value of score after destroing hazard  // call it in destroyByContent script
    {
        Score += newScoreValue;    //plus value which come to old score
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score : " + Score;   // score : 0
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
