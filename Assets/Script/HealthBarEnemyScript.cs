using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemyScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text TextHealth;

    public void SetMaxHealth(int health)
    {
        fill.color = gradient.Evaluate(1f);
        slider.maxValue = health;
    }
    public void SetHealth(int health)
    {
        if (health < 0)
        {
            TextHealth.text = "0";
        }
        else
        {
            TextHealth.text = health.ToString();
        }
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
