using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourcePerDmg : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] int dmg=0;
    [SerializeField] TMP_Text damageText;
    [SerializeField] FormattingNumbers num;
    [SerializeField] Planethealth ptHp;
    TestShop shipList; //damage all the ships

    public int Dmg
    { get { return dmg; } set {  dmg = value; } }

    public void DmgPerClick()
    {
        // Initialize the TestShop reference by finding the TestShop component in the scene
        shipList = FindObjectOfType<TestShop>();
        dmg = 0;
        // Check if testShop is not null before accessing its SpaceShips list
        if (shipList != null && shipList.SpaceShips.Count > 0)
        {  
            for (int i = 0; i < shipList.SpaceShips.Count; i++)
                dmg += shipList.SpaceShips[i].ShipDmg;
            game.setResource((int)(game.GetResource() + game.GetResourceMultiplier() * dmg));
            game.ResourcesText.text = num.AbbreviateNumber(game.GetResource()); //pokazuje resurse prikupljene pri udarcu
            damageText.text = num.AbbreviateNumber(dmg); //formatira text damage-a
            ptHp.TakeDamage(dmg);
        }
    }
}