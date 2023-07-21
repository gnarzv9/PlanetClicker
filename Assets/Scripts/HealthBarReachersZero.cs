using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarReachersZero : MonoBehaviour
{
    public Game game;
    public Planethealth planethealth;
    public HealthBar healthbar;

    public FormattingNumbers numbers;

    // Start is called before the first frame update
    void Start()
    {
        if(planethealth.currentHealth <= 0)
        {
            game.SetRebirthResource((int)(game.GetRebirthResource() * planethealth.maxHealth * 0.1));
            game.rebirthText.text = numbers.AbbreviateNumber(game.GetRebirthResource());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (planethealth.currentHealth <= 0)
        {
            game.SetRebirthResource((int)(game.GetRebirthResource() + planethealth.maxHealth * 0.1));
            game.rebirthText.text = numbers.AbbreviateNumber(game.GetRebirthResource());
            Debug.Log("Dodao sam: " + planethealth.maxHealth * 0.1);
            planethealth.currentHealth = (int)(planethealth.maxHealth * 1.5);
            planethealth.maxHealth = planethealth.currentHealth;
            healthbar.SetMaxHealth(planethealth.maxHealth);
        }

    }
}
