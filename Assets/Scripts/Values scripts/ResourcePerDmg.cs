using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourcePerDmg : MonoBehaviour, IDataPresistance
{
    [SerializeField] private Game game;
    [SerializeField] private int dmg=0;
    [SerializeField] private float dmgScaling = 1;
    [SerializeField] TMP_Text damageText;
    [SerializeField] FormattingNumbers num;
    [SerializeField] Planethealth ptHp;
    TestShop shipList; //damage all the ships

    public void LoadData(GameData data)
    {
        this.dmgScaling = data.dmgScaling;

    }

    public void SaveData(ref GameData data)
    {
        data.dmgScaling = this.dmgScaling;

    }


    public int Dmg
    { get { return dmg; } set {  dmg = value; } }

    public float DmgScaling
    { get { return dmgScaling; } set { dmgScaling = value; } }
    public void DmgPerClick()
    {
        // Initialize the TestShop reference by finding the TestShop component in the scene
        shipList = FindObjectOfType<TestShop>();
        dmg = 0;
        // Check if testShop is not null before accessing its SpaceShips list
        if (shipList != null && shipList.SpaceShips.Count > 0)
        {  
            for (int i = 0; i < shipList.SpaceShips.Count; i++)
                dmg += (int)(shipList.SpaceShips[i].ShipDmg * dmgScaling);
            game.setResource((int)(game.GetResource() + game.GetResourceMultiplier() * dmg));
            game.ResourcesText.text = num.AbbreviateNumber(game.GetResource()); //pokazuje resurse prikupljene pri udarcu
            damageText.text = num.AbbreviateNumber(dmg); //formatira text damage-a
            ptHp.TakeDamage(dmg);
        }
    }
}