using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("updating scoroe");
        scoreText.text = gameController.GetScore().ToString();
    }

    //public void DisplayScore()
    //{
    //    scoreText.text = gameController.GetScore().ToString();
    //}
}
