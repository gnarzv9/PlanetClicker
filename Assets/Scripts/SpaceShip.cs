using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private int shipDmg;
    [SerializeField] private int shipPrice;
    [SerializeField] private int firstDmgValue;
    [SerializeField] private int upgradeValue;
    [SerializeField] private int upgradePrice;
    [SerializeField] FormattingNumbers numbers;
    [SerializeField] TMP_Text priceText;
    [SerializeField] TMP_Text damageText;

    public int ShipPrice
    {
        get { return shipPrice;}
        set { shipPrice = value;}
    }

    public int ShipDmg
    {
        get { return shipDmg; }
        set { shipDmg = value; }
    }

    public SpaceShip(int dmg ,int price)
    {
        shipDmg = dmg;
        shipPrice = price;
        damageText.text = numbers.AbbreviateNumber(shipDmg) + "dmg"; //text damage-a
        priceText.text = numbers.AbbreviateNumber(shipPrice) + "$";
    }

    public void Upgrade()
    {
        shipDmg += upgradeValue;
        shipPrice += upgradePrice;
        priceText.text = numbers.AbbreviateNumber(shipPrice) + "$";
        damageText.text = numbers.AbbreviateNumber(shipDmg) + "dmg";
    }

    public void FirstUpgrade()
    {
        shipDmg += firstDmgValue;
        shipPrice += upgradePrice;
        priceText.text = numbers.AbbreviateNumber(shipPrice) + "$";
        damageText.text = numbers.AbbreviateNumber(shipDmg) + "dmg";
    }
}
