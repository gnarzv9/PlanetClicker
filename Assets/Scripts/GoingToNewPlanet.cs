using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoingToNewPlanet : MonoBehaviour
{
    public Game game;
    public Planethealth planethealth;
    public HealthBar healthbar;
    //public Image Planet1;
    //public Sprite Planet2;

    // Start is called before the first frame update
    void Start()
    {
        if(planethealth.currentHealth <= 0)
        {
            game.setResource((int)(game.GetResource() * planethealth.maxHealth * 0.1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (planethealth.currentHealth <= 0)
        {
            game.setResource((int)(game.GetResource() + planethealth.maxHealth * 0.1));
            Debug.Log("Dodao sam: " + planethealth.maxHealth * 0.1);
            planethealth.currentHealth = (int)(planethealth.maxHealth * 1.5);
            planethealth.maxHealth = planethealth.currentHealth;
            healthbar.SetMaxHealth(planethealth.maxHealth);
            //Planet1.sprite = Planet2;
        }

    }
}
