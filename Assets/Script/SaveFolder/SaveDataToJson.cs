using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveDataToJson : MonoBehaviour
{
    public InputField NewUserName;
    public InputField NewPassword;
    public InputField LoginUserName;
    public InputField LoginPassword;

    public Database Newdatabaseclass;

    public bool _used;
    public bool _userlogin;

    public Text errortext;
    public Text messagetext;

    public GameObject loadingScreen;
    public Slider loadingslider;

    public void Start()
    {
        if (!File.Exists(Application.dataPath + "/PlayerData.json"))
        {
            Database data = new Database();
            data.database.Add(new UserData
            {
                UserName = "Player",
                Password = "12345",
                ScorePlayer = 0,
                HealthPlayer = 0,
                HealthEnemy = 0,
                PosX = 0,
                PosY = 0,
                PosZ = 0,
                RotY = 0,
                CurrentScene = "Level 1",
                Saved = 0,
                HighScorePlayer = 0
            });
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
        }
    }
    public void SavetoJson()
    {
        if (NewUserName.text=="" && NewPassword.text =="")
        {
            messagetext.text = "Input your new username and new password";
        }
        else
        {
            if (File.Exists(Application.dataPath + "/PlayerData.json"))
            {
                string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
                Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);
                _used = false;
                for (int i = 0; i < Newdatabaseclass.database.Count; i++)
                {
                    if (Newdatabaseclass.database[i].UserName == NewUserName.text)
                    {
                        Debug.Log(NewUserName.text);
                        _used = true;
                        Debug.Log(_used);
                    }
                }

                if (_used == false)
                {
                    Newdatabaseclass.database.Add(new UserData
                    {
                        UserName = NewUserName.text,
                        Password = NewPassword.text,
                        ScorePlayer = 0,
                        HealthPlayer = 0,
                        HealthEnemy = 0,
                        PosX = 0,
                        PosY = 0,
                        PosZ = 0,
                        RotY = 0,
                        CurrentScene = "Level 1",
                        Saved = 0,
                        HighScorePlayer = 0
                    });
                    string json = JsonUtility.ToJson(Newdatabaseclass, true);
                    File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
                    messagetext.text = "Register Succefully, please Login";
                    NewUserName.text = "";
                    NewPassword.text = "";
                    StartCoroutine(errortextnone());
                }
                else
                {
                    Debug.Log(_used);
                    messagetext.text = "Username already used";
                    StartCoroutine(errortextnone());
                }
            }
            else
            {
                Database data = new Database();
                data.database.Add(new UserData
                {
                    UserName = NewUserName.text,
                    Password = NewPassword.text,
                    ScorePlayer = 0,
                    HealthPlayer = 0,
                    HealthEnemy = 0,
                    PosX = 0,
                    PosY = 0,
                    PosZ = 0,
                    RotY = 0,
                    CurrentScene = "Level 1",
                    Saved = 0,
                    HighScorePlayer = 0
                });
                string json = JsonUtility.ToJson(data, true);
                File.WriteAllText(Application.dataPath + "/PlayerData.json",json);

            }
        }
        
    }

    public void login()
    {
        string jsonload = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        Newdatabaseclass = JsonUtility.FromJson<Database>(jsonload);
        _userlogin = false;
        for (int i=0;i<Newdatabaseclass.database.Count; i++)
        {
            if (Newdatabaseclass.database[i].UserName == LoginUserName.text) {
                if (Newdatabaseclass.database[i].Password == LoginPassword.text)
                {
                    Debug.Log("LOGIN SUCESS");
                    // SceneManager.LoadScene("MenuUtama");
                    StartCoroutine(MenuLoad());
                    PlayerPrefs.SetString("PlayerUsername", LoginUserName.text);
                    _userlogin = true;
                }
            }
        }

        if (_userlogin==false)
        {
            Debug.Log("INVALID USERNAME");
            errortext.text = "INVALID USERNAME or PASSWORD";
            StartCoroutine(errortextnone());
        }
    }

    public IEnumerator errortextnone()
    {
        yield return new WaitForSeconds(3f);
        errortext.text = "";
        messagetext.text = "";
    }

    public void logout()
    {
        PlayerPrefs.DeleteKey("PlayerUsername");
    }

    IEnumerator MenuLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("MenuUtama");

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingslider.value = progress;
            Debug.Log(progress);
            yield return null;
        }

    }


     public void newgame()
    {
        string playername = PlayerPrefs.GetString("PlayerUsername");
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
                Newdatabaseclass.database[i].CurrentScene = "Level 1";
                Newdatabaseclass.database[i].Saved = 0;

            }
        }
        string json = JsonUtility.ToJson(Newdatabaseclass, true);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
    }

}
