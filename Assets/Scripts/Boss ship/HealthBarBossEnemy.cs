using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBossEnemy : MonoBehaviour
{


    public Slider slider;

    public void SetMaxHealthBoss(int health){
        slider.maxValue=health;
        slider.value=health;
    }

    public void SetHealthBoss(int health){
        slider.value=health;
    }
}

