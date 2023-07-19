using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstronautShop : MonoBehaviour
{
    //skripa povezana sa drugom skriptom (nista jos ne radi)

    public Game script;
    public GameObject BuyButton1; //button trenutno povezan na astraunt button

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(script.Resources >= 50)
        {
            BuyButton1.SetActive(true);
           // script.setResourceMultiplier(script.ResourcesMultiplier+2);
        }

    }
}
