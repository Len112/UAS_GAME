using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem  sScoresystem;
    public int playerScore = 0;
    public Text scoreText;
    public AudioSource scoreSound;
    // Start is called before the first frame update
    void Start()
    {
        sScoresystem = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int increase)
    {
        playerScore += increase;
        scoreText.text = "SCORE : " + playerScore.ToString();
        scoreSound.Play();
    }
}
