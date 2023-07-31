using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShipsToPick : MonoBehaviour
{
    [SerializeField] private TestShop shop;
    [SerializeField] private GameObject[] BossButton;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shop.NumberOfShips; i++)
        {
            if (shop.SpaceShips[i].ShipDmg <= 0)
            {
                BossButton[i].SetActive(false);
            }
            else
                BossButton[i].SetActive(true);
        }
    }
}
