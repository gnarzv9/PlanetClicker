using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressShop : MonoBehaviour
{
    [SerializeField] private TestShop shop;
    [SerializeField] private GameObject[] buttons;
    private void Update()
    {
        for (int i = 0; i < shop.NumberOfShips; i++)
        {
            if (shop.SpaceShips[i].ShipDmg <= 0)
            {
                buttons[i + 1].SetActive(false);
            }
            else
            {
                buttons[i + 1].SetActive(true);
            }
        }
    }
}
