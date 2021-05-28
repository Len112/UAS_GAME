using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDataFromJson : MonoBehaviour
{
    public Database Newdatabaseclass;

    public Text PlayerUsername;
    // Start is called before the first frame update
    void Awake()
    {
        string playername = PlayerPrefs.GetString("PlayerUsername");
        PlayerUsername.text =playername;
        Debug.Log(playername);
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);
 
        for (int i = 0; i < Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == playername)
            {
                PlayerPrefs.SetFloat("PosX", Newdatabaseclass.database[i].PosX);
                PlayerPrefs.SetFloat("PosY", Newdatabaseclass.database[i].PosY);
                PlayerPrefs.SetFloat("PosZ", Newdatabaseclass.database[i].PosZ);
                PlayerPrefs.SetFloat("RotY", Newdatabaseclass.database[i].RotY);
                PlayerPrefs.SetInt("HealthSave", Newdatabaseclass.database[i].HealthPlayer);
                PlayerPrefs.SetInt("ScoreSave", Newdatabaseclass.database[i].ScorePlayer);
                PlayerPrefs.SetInt("HealthEnemySave", Newdatabaseclass.database[i].HealthEnemy);
                PlayerPrefs.SetString("CurrentLevel", Newdatabaseclass.database[i].CurrentScene);
                PlayerPrefs.SetInt("Saved", Newdatabaseclass.database[i].Saved);
                PlayerPrefs.SetInt("HighScore", Newdatabaseclass.database[i].HighScorePlayer);
            }
        }
        Debug.Log(PlayerPrefs.GetString("CurrentLevel"));
    }
}
