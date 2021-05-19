using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUtama : MonoBehaviour
{
  
    public InputField playername;

    
    
    public void SavePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", playername.text);
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
    }
   

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
