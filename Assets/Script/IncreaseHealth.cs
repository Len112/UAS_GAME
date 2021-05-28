using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{
    public PlayerHealth Increasehealth;
    public HealthBarScript healthBar;

    public AudioSource Bottle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Increasehealth.CurrentHealth += 5;
            healthBar.SetHealth(Increasehealth.CurrentHealth);
            Bottle.Play();
            Destroy(this.gameObject);
        }
    }
}
