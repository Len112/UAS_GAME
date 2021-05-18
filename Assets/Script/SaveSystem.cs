using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public GameObject playerPosition;
    public PlayerHealth healthplayer;
    public EnemyHealth healthenemy;
    public ScoreSystem scoregame;

    string sceneName;

    public InputField playername;

    private void Start()
    {
       
    }
    public void SavePlayer()
    {
        PlayerPrefs.SetFloat("PosX", playerPosition.transform.position.x);
        PlayerPrefs.SetFloat("PosY", playerPosition.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", playerPosition.transform.position.z);
        PlayerPrefs.SetFloat("RotY", playerPosition.transform.rotation.y);
        PlayerPrefs.SetInt("HealthSave", healthplayer.CurrentHealth);
        PlayerPrefs.SetInt("ScoreSave", scoregame.playerScore);
        PlayerPrefs.SetInt("HealthEnemySave", healthenemy.CurrentHealth);
        sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurrentLevel", sceneName);
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("PlayerName",playername.text);
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
    }
    public void restart()
    {
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
        PlayerPrefs.DeleteKey("RotY");
        PlayerPrefs.DeleteKey("HealthSave");
        PlayerPrefs.DeleteKey("ScoreSave");
        PlayerPrefs.DeleteKey("HealthEnemySave");
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public void NextLevel2()
    {
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
        PlayerPrefs.DeleteKey("RotY");
        PlayerPrefs.SetString("CurrentLevel", "Level 2");
    }

    public void NextLevel3()
    {
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
        PlayerPrefs.DeleteKey("RotY");
        PlayerPrefs.SetString("CurrentLevel", "Level 3");
    }
}
