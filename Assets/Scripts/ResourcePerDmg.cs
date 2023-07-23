using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourcePerDmg : MonoBehaviour
{
    public Game game;
    public int Dmg;
    TestShop testShop; //damage all the ships
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the TestShop reference by finding the TestShop component in the scene
        testShop = FindObjectOfType<TestShop>();
    }
    // Update is called once per frame
    void Update()
    {
        // Check if testShop is not null before accessing its SpaceShips list
        if (testShop != null && testShop.SpaceShips.Count > 0)
        {
            Dmg = testShop.SpaceShips[0].ShipDmg;
            game.setResource((int)(game.GetResource() + 0.2 * Dmg));
            Debug.Log(Dmg);
        }
    }

    void DmgPerClick()
    {
        Debug.Log(Dmg);
    }
}