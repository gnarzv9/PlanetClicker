using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceShip : MonoBehaviour
{
    //objekti u vezi brodova
    [SerializeField] private int shipHp;
    [SerializeField] private int shipDmg;
    [SerializeField] private int shipPrice;
    [SerializeField] private int firstUpgrade;
    [SerializeField] private int upgradeValue;
    [SerializeField] private int upgradePrice;
    //objekti u vezi teksta
    [SerializeField] FormattingNumbers numbers;
    [SerializeField] TMP_Text priceText;
    [SerializeField] TMP_Text damageText;

    public void Start()
    {
        priceText.text = numbers.AbbreviateNumber(shipPrice) + "$";
        damageText.text = numbers.AbbreviateNumber(shipDmg) + "dmg";
    }

    public int ShipPrice
    {
        get { return shipPrice; }
        set { shipPrice = value; }
    }

    public int ShipDmg
    {
        get { return shipDmg; }
        set { shipDmg = value; }
    }

    //inicijalizacija pocetnog damage i cene broda
    public SpaceShip(int dmg, int price)
    {
        shipDmg = dmg;
        shipPrice = price;
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
        shipDmg += firstUpgrade;
        shipPrice += upgradePrice;
        priceText.text = numbers.AbbreviateNumber(shipPrice) + "$";
        damageText.text = numbers.AbbreviateNumber(shipDmg) + "dmg";
    }
}