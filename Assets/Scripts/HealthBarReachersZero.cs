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
    public RebirthScript rebirth;
    public FormattingNumbers numbers;

    // Start is called before the first frame update
    void Start()
    {
        if(planethealth.currentHealth <= 0)
        {
            rebirth.setPreRebirthResource((int)(rebirth.GetPreRebirthResource() * planethealth.maxHealth * 0.1));
            rebirth.PreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (planethealth.currentHealth <= 0)
        {
            rebirth.setPreRebirthResource((int)(rebirth.GetPreRebirthResource() + planethealth.maxHealth * 0.1));
            rebirth.PreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
            Debug.Log("Dodao sam: " + planethealth.maxHealth * 0.1);
            planethealth.currentHealth = (int)(planethealth.maxHealth * 1.5);
            planethealth.maxHealth = planethealth.currentHealth;
            healthbar.SetMaxHealth(planethealth.maxHealth);
        }

    }
}
