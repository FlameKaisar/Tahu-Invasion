using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{
    public Slider slider;


    public void SetMaxHealthBoss(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


    public void SetHealthBoss(float health)
    {
        slider.value = health;
    }
}
