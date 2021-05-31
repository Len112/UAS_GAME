using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public GameObject playerPosition;
    public PlayerHealth healthplayer;
    public EnemyHealth healthenemy;
    public ScoreSystem scoregame;

    string sceneName;


    public Database Newdatabaseclass;
    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void SavePlayer()
    {
        string playerusername = PlayerPrefs.GetString("PlayerUsername");
        Debug.Log(playerusername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);

        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playerusername)
            {
                Newdatabaseclass.database[i].PosX = playerPosition.transform.position.x;
                Newdatabaseclass.database[i].PosY = playerPosition.transform.position.y;
                Newdatabaseclass.database[i].PosZ = playerPosition.transform.position.z;
                Newdatabaseclass.database[i].RotY = playerPosition.transform.eulerAngles.y;
                Newdatabaseclass.database[i].HealthPlayer = healthplayer.CurrentHealth;
                Newdatabaseclass.database[i].ScorePlayer = scoregame.playerScore;
                Newdatabaseclass.database[i].HealthEnemy = healthenemy.CurrentHealth;
                Newdatabaseclass.database[i].CurrentScene = sceneName;
                Newdatabaseclass.database[i].Saved = 1;
            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
    }

   
    public void restart()
    {
        string playername = PlayerPrefs.GetString("PlayerUsername");
        Debug.Log(playername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);

        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playername)
            {
                Newdatabaseclass.database[i].PosX = 0;
                Newdatabaseclass.database[i].PosY = 0;
                Newdatabaseclass.database[i].PosZ = 0;
                Newdatabaseclass.database[i].RotY = 0;
                Newdatabaseclass.database[i].HealthPlayer = 0;
                Newdatabaseclass.database[i].ScorePlayer = 0;
                Newdatabaseclass.database[i].HealthEnemy = 0;
                Newdatabaseclass.database[i].CurrentScene = sceneName;
            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
    }

    public void restart2()
    {
        string playername = PlayerPrefs.GetString("PlayerUsername");
        Debug.Log(playername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);

        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playername)
            {
                Newdatabaseclass.database[i].PosX = 0;
                Newdatabaseclass.database[i].PosY = 0;
                Newdatabaseclass.database[i].PosZ = 0;
                Newdatabaseclass.database[i].RotY = 0;
                Newdatabaseclass.database[i].HealthPlayer = 0;
                Newdatabaseclass.database[i].ScorePlayer = PlayerPrefs.GetInt("ScoreSavefrom1");
                Newdatabaseclass.database[i].HealthEnemy = 0;
            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
    }

    public void restart3()
    {
        string playername = PlayerPrefs.GetString("PlayerUsername");
        Debug.Log(playername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);

        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playername)
            {
                Newdatabaseclass.database[i].PosX = 0;
                Newdatabaseclass.database[i].PosY = 0;
                Newdatabaseclass.database[i].PosZ = 0;
                Newdatabaseclass.database[i].RotY = 0;
                Newdatabaseclass.database[i].HealthPlayer = 0;
                Newdatabaseclass.database[i].ScorePlayer = PlayerPrefs.GetInt("ScoreSavefrom2");
                Newdatabaseclass.database[i].HealthEnemy = 0;
            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public void NextLevel2()
    {
        PlayerPrefs.SetInt("ScoreSavefrom1", scoregame.playerScore);
        string playername = PlayerPrefs.GetString("PlayerUsername");
        Debug.Log(playername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);

        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playername)
            {
                Newdatabaseclass.database[i].PosX = 0;
                Newdatabaseclass.database[i].PosY = 0;
                Newdatabaseclass.database[i].PosZ = 0;
                Newdatabaseclass.database[i].RotY = 0;
                Newdatabaseclass.database[i].HealthPlayer = 0;
                Newdatabaseclass.database[i].ScorePlayer = scoregame.playerScore;
                Newdatabaseclass.database[i].HealthEnemy = 0;
                Newdatabaseclass.database[i].CurrentScene = "Level 2";
                Newdatabaseclass.database[i].Saved = 1;
            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
        Time.timeScale = 1;
        PlayerPrefs.SetString("CurrentLevel", "Level 2");
    }

    public void NextLevel3()
    {
        PlayerPrefs.SetInt("ScoreSavefrom2", scoregame.playerScore);
        string playername = PlayerPrefs.GetString("PlayerUsername");
        Debug.Log(playername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);

        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playername)
            {
                Newdatabaseclass.database[i].PosX = 0;
                Newdatabaseclass.database[i].PosY = 0;
                Newdatabaseclass.database[i].PosZ = 0;
                Newdatabaseclass.database[i].RotY = 0;
                Newdatabaseclass.database[i].HealthPlayer = 0;
                Newdatabaseclass.database[i].ScorePlayer = scoregame.playerScore;
                Newdatabaseclass.database[i].HealthEnemy = 0;
                Newdatabaseclass.database[i].CurrentScene = "Level 3";
                Newdatabaseclass.database[i].Saved = 1;
            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
        PlayerPrefs.SetString("CurrentLevel", "Level 3");
        Time.timeScale = 1;
    }

    public void Win()
    {
        string playername = PlayerPrefs.GetString("PlayerUsername");
        Debug.Log(playername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);

        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playername)
            {
                Newdatabaseclass.database[i].PosX = 0;
                Newdatabaseclass.database[i].PosY = 0;
                Newdatabaseclass.database[i].PosZ = 0;
                Newdatabaseclass.database[i].RotY = 0;
                Newdatabaseclass.database[i].HealthPlayer = 0;
                Newdatabaseclass.database[i].ScorePlayer = scoregame.playerScore;
                Newdatabaseclass.database[i].HealthEnemy = 0;
                Newdatabaseclass.database[i].CurrentScene = "WinScene";
                Newdatabaseclass.database[i].Saved = 1;
                if (Newdatabaseclass.database[i].HighScorePlayer < scoregame.playerScore)
                {
                    Newdatabaseclass.database[i].HighScorePlayer = scoregame.playerScore;
                }
            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
        PlayerPrefs.SetString("CurrentLevel", "WinScene");
        Time.timeScale = 1;
    }
}
