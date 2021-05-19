using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public int damage;

    public HealthBarEnemyScript healthBar;

    public EnemyMove enemymove;

    public GameObject WinCanvas;

    Animator anim;

    public AudioSource roar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        anim = GetComponentInChildren<Animator>();
        if (PlayerPrefs.HasKey("HealthEnemySave"))
        {
            CurrentHealth = PlayerPrefs.GetInt("HealthEnemySave");
            healthBar.SetHealth(CurrentHealth);
        }
        else
        {
            CurrentHealth = MaxHealth;
            healthBar.SetHealth(CurrentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CurrentHealth <= 0)
        {
            anim.SetTrigger("Die");
            enemymove.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            roar.Stop();
            StartCoroutine(Win());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CurrentHealth -= damage;
                healthBar.SetHealth(CurrentHealth);
                anim.SetTrigger("Damage");
            }

        }
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(2f);
        WinCanvas.SetActive(true);
        Time.timeScale = 0;
    }

}
