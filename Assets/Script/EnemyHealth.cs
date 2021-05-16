using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public HealthBarEnemyScript healthBar;
    public EnemyMove enemymove;
    Animator anim;

    public AudioSource roar;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(CurrentHealth);
        healthBar.SetMaxHealth(MaxHealth);
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CurrentHealth <= 0)
        {
            anim.SetTrigger("Die");
            enemymove.enabled = false;
            roar.Stop();
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
                CurrentHealth -= 10;
                healthBar.SetHealth(CurrentHealth);
                anim.SetTrigger("Damage");
            }

        }
    }

}
