﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button cont;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            cont.interactable = false;
        }
    }

}