using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlanetTransition : MonoBehaviour
{
    [SerializeField] private Planethealth planetHp;
    [SerializeField] private Animator changePlanet;
    [SerializeField] private Animator changePlanetIcon;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(changePlanet != null)
        {
            if (planetHp.maxHealth == 150000 && triggered==false)
            {
                changePlanet.SetTrigger("planet2Tr");
                changePlanetIcon.SetTrigger("planet2Tr");
                Debug.Log("Treba da promeni planetu");    
                triggered = true;
            }
        }
    }
}
