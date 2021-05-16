using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public HealthBarScript healthBar;
    Animator anim;
    public AudioSource getHitAudio;
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

        if (CurrentHealth <=0)
        {
            anim.SetTrigger("die");
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            if (!Input.GetKeyDown(KeyCode.Mouse1))
            {
                CurrentHealth -= 2;
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
}
