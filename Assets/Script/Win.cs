using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject wincanvas;
    public Text resultscore;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(wait());
        if (PlayerPrefs.GetInt("ScoreSave")==0)
        {
            resultscore.text = "Putri sedih sekali dengan banyaknya hadiah yang kamu bawa";
        }else if (PlayerPrefs.GetInt("ScoreSave") < 100)
        {
            resultscore.text = "Putri kecewa dengan banyaknya hadiah yang kamu bawa";
        }else if (PlayerPrefs.GetInt("ScoreSave") >= 100 && PlayerPrefs.GetInt("ScoreSave") < 250)
        {
            resultscore.text = "Putri senang dengan banyaknya hadiah yang kamu bawa";
        }
        else if (PlayerPrefs.GetInt("ScoreSave") >= 250)
        {
            resultscore.text = "Putri senang sekali dengan banyaknya hadiah yang kamu bawa";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        wincanvas.SetActive(true);
    }
}
