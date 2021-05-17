using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{

    public NewPlayerLook mouse;
    private void Start()
    {
    }
    public void MenuUtama()
    {
        SceneManager.LoadScene("MenuUtama");
        Time.timeScale = 1;
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void unpause()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        mouse.enabled = true;
    }

   public void currentLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
        Time.timeScale = 1;
    }
}
