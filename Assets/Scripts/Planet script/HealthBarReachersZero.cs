using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

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
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        LastPlanetHealth();
        yield return null;
    }

    public void LastPlanetHealth()
    {
        for(int i = 1; i < newPlanet.PlanetNum; i++)
        {
            planethealth.CurrentHealth = (int)(planethealth.MaxHealth * 1.5);
            planethealth.MaxHealth = planethealth.CurrentHealth;
            healthbar.SetMaxHealth(planethealth.MaxHealth);
            Debug.Log("povecani helti za " + i + "puta");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (planethealth.CurrentHealth <= 0)
        {
            if (newPlanet.BossPlanet() == false)
            {
                rebirth.setPreRebirthResource((int)(rebirth.GetPreRebirthResource() + planethealth.MaxHealth * 0.1));
                rebirth.PreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
                rebirth.shopPreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
                Debug.Log("Dodao sam: " + planethealth.MaxHealth * 0.1);
                planethealth.CurrentHealth = (int)(planethealth.MaxHealth * 1.5);
                planethealth.MaxHealth = planethealth.CurrentHealth;
                healthbar.SetMaxHealth(planethealth.MaxHealth);
            }
            else
            {
                rebirth.setPreRebirthResource((int)(rebirth.GetPreRebirthResource() + planethealth.MaxHealth * 0.1));
                rebirth.PreRebirthText.text = numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
                rebirth.shopPreRebirthText.text = "+" + numbers.AbbreviateNumber(rebirth.GetPreRebirthResource());
                planethealth.CurrentHealth = planethealth.MaxHealth;
            }
            FindObjectOfType<AudioMangaer>().Play("explosion");
            //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            changedHp = true;
        }
        else changedHp = false; 
    }
}
