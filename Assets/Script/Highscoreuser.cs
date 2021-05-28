using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscoreuser : MonoBehaviour
{
    public Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            highscore.text = "HIGHSCORE : Please Finish all level to see your highscore";
        }
        else 
        {
            highscore.text = "HIGHSCORE :"+ PlayerPrefs.GetInt("HighScore").ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
