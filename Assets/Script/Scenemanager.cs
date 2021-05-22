using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenemanager : MonoBehaviour
{

    public NewPlayerLook mouse;

    public GameObject loadingScreen;
    public Slider loadingslider;

    private void Start()
    {
    }
    public void MenuUtama()
    {
        Time.timeScale = 1;
        StartCoroutine(Loadscene("MenuUtama"));
    }
    public void LoginScene()
    {
        Time.timeScale = 1;
        StartCoroutine(Loadscene("LoginScene"));
    }
    public void Level1()
    {
        StartCoroutine(Loadscene("Level 1"));
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
        StartCoroutine(Loadscene(PlayerPrefs.GetString("CurrentLevel")));
        Time.timeScale = 1;
        Debug.Log(PlayerPrefs.GetString("CurrentLevel"));
    }

    IEnumerator Loadscene(string scenename)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingslider.value = progress;

            yield return null;
        }

    }
}
