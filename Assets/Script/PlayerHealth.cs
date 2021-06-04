using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public int hit;

    public HealthBarScript healthBar;

    Animator anim;

    public AudioSource getHitAudio;

    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HealthSave")!=0)
        {
            CurrentHealth = PlayerPrefs.GetInt("HealthSave");
            healthBar.SetHealth(CurrentHealth);
        }
        else {
            CurrentHealth = MaxHealth;
            healthBar.SetHealth(CurrentHealth);
        }
        healthBar.SetMaxHealth(MaxHealth);
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if (CurrentHealth <=0)
        {
            anim.SetTrigger("die");
            GameOverCanvas.SetActive(true);
            StartCoroutine(GameOver());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            if (!Input.GetKeyDown(KeyCode.Mouse1))
            {
                CurrentHealth -= hit;
                healthBar.SetHealth(CurrentHealth);
                StartCoroutine(GetHit());
            } 
        }
    }

    private IEnumerator GetHit()
    {
        getHitAudio.Play();
        anim.SetLayerWeight(anim.GetLayerIndex("Hit_Layer"), 1);
        anim.SetTrigger("gethit");
        yield return new WaitForSeconds(0.5f);
        anim.SetLayerWeight(anim.GetLayerIndex("Hit_Layer"), 0);
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }
}
