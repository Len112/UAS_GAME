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
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CurrentHealth <= 0)
        {
            anim.SetBool("EnemyAttack", false);
            anim.SetTrigger("Death");
            enemymove.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            {
                CurrentHealth -= 10;
                healthBar.SetHealth(CurrentHealth);
                anim.SetTrigger("Hit");
            }

        }
    }
}
