using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Win;
    public EnemyHealth enemyHealth;
    public PlayerHealth playerHealth;
    public AudioSource audioGameOver;
    public AudioSource audioWin;

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.CurrentHealth <= 0){
            GameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            audioGameOver.Play();
            Time.timeScale = 0;
        }
        if (enemyHealth.CurrentHealth <= 0)
        {
            Win.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            audioWin.Play();
            Time.timeScale = 0;
        }
    }
}
