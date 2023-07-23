using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShop : MonoBehaviour
{ 
    public Game game;
    public ResourcePerDmg dmg;
    public int DmgShip1 = 20;
    public int DmgShip2 = 0;
    public int DmgShip3 = 0;
    private int PriceShip1;
    private int PriceShip2;   
    private int PriceShip3;
    public bool ship2Unlocked = false;
    public bool ship3Unlocked = false;
    public GameObject ShopPanel;

    private void Start()
    {
        PriceShip1 = 50;
        PriceShip2 = 1000;
        PriceShip3 = 2000;
    }
    public void OpenCloseShop()
    {
        if (ShopPanel.activeInHierarchy == false)
            ShopPanel.SetActive(true);
        else ShopPanel.SetActive(false);
    }

    public void UpgradeShip1()
    {
        if (game.GetResource() >= PriceShip1)
        {
            game.setResource(game.GetResource() - PriceShip1);
            DmgShip1 += 20;
            PriceShip1 += 50;
            Debug.Log("Upgrejdovao 1 ship");
        }
    }

    public void UpgradeShip2()
    {
        if (PriceShip2 == 1000 && game.GetResource() >= PriceShip3)
        {
            game.setResource(game.GetResource() - PriceShip2);
            PriceShip2 += 150;
            DmgShip2 = 1000;
            Debug.Log("Otkljucao 2 ship");
            ship2Unlocked = true;
        }
        else if (game.GetResource() >= PriceShip2)
        {
            game.setResource(game.GetResource() - PriceShip2);
            DmgShip2 += 100;
            PriceShip2 += 150;
            Debug.Log("Upgrejdovao 2 ship");
        }
    }

    public void UpgradeShip3()
    {
        if (PriceShip3 == 2000 && game.GetResource() >= PriceShip3)
        {
            game.setResource(game.GetResource() - PriceShip3);
            DmgShip3 = 1500;
            PriceShip3 += 300;
            Debug.Log("Otkljucao 3 ship");
            ship3Unlocked = true;
        }
        else if(game.GetResource() >= PriceShip3)
        {
            game.setResource(game.GetResource() - PriceShip3);
            DmgShip3 += 200;
            PriceShip3 += 300;
            Debug.Log("Upgrejdovao 3 ship");
        }
    }
        
}
