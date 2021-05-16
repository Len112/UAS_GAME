using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Restart1()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
