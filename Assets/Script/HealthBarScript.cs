using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text TextHealth;
    public Text TextPlayer;

    void Start()
    {
       
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (health < 0)
        {
            TextHealth.text = "0";
        }else if(health > 100)
        {
            TextHealth.text = "100";
        }
        else
        {
            TextHealth.text = health.ToString();
        }
    }

   
}
