using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerAudio : MonoBehaviour
{
    public AudioSource walkaudio;
    public AudioSource walkaudio2;
    public AudioSource runaudio;
    public AudioSource jumpaudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            walkaudio.Play();
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
            walkaudio2.Play();
        } else if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            walkaudio.Play();
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            walkaudio2.Play();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkaudio.Stop();
            runaudio.Play();
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            walkaudio.Stop();
            runaudio.Stop();
            jumpaudio.Play();
        } else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            walkaudio.Stop();
        } else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            walkaudio2.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            walkaudio.Stop();
        }else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            walkaudio2.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runaudio.Stop();
        }
    }
}
