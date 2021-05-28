using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button cont;

    public GameObject newgameconfirmation;

    public SaveDataToJson newGame;
    public Scenemanager level1;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Saved")==0)
        {
            cont.interactable = false;
        }
    }

    public void newgame()
    {
        if (PlayerPrefs.GetInt("Saved") == 1)
        {
            newgameconfirmation.SetActive(true);
        }
        else
        {
            newGame.newgame();
            level1.Level1();
        }
    }

}
