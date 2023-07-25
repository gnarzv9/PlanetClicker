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
    private bool changedHp;
    [SerializeField] private NewPlanetTransition newPlanet;

    public bool ChangedHp
    { get { return changedHp; } set { changedHp = value; } }

    // Start is called before the first frame update
    void Start()
    {
        if(planethealth.CurrentHealth <= 0) //dodati kad cuvanje progresa
        {
            rebirth.setPreRebirthResource((int)(rebirth.GetPreRebirthResource() * planethealth.MaxHealth * 0.1));
            rebirth.PreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (planethealth.CurrentHealth <= 0)
        {
            if (newPlanet.OnTheSamePlanet() == false)
            {
                rebirth.setPreRebirthResource((int)(rebirth.GetPreRebirthResource() + planethealth.MaxHealth * 0.1));
                rebirth.PreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
                Debug.Log("Dodao sam: " + planethealth.MaxHealth * 0.1);
                planethealth.CurrentHealth = (int)(planethealth.MaxHealth * 1.5);
                planethealth.MaxHealth = planethealth.CurrentHealth;
                healthbar.SetMaxHealth(planethealth.MaxHealth);
                changedHp = true;
            }
            else
            {
                rebirth.setPreRebirthResource((int)(rebirth.GetPreRebirthResource() + planethealth.MaxHealth * 0.1));
                rebirth.PreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
                planethealth.CurrentHealth = planethealth.MaxHealth;
            }
        }
        else { changedHp = false; }
    }
}
