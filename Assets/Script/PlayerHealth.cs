using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public HealthBarScript healthBar;
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

        if (CurrentHealth <=0)
        {
            anim.SetTrigger("die");
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            CurrentHealth -= 2;
            healthBar.SetHealth(CurrentHealth);
            StartCoroutine(GetHit());
        }
    }

    private IEnumerator GetHit()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Hit_Layer"), 1);
        anim.SetTrigger("gethit");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Hit_Layer"), 0);


    }
}
