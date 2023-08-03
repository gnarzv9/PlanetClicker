using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceShip : MonoBehaviour , IDataPresistance
{
    [SerializeField] private string id;
    [SerializeField] private string idPrice;


    //objekti u vezi brodova
    [SerializeField] private int shipDmg;
    [SerializeField] private int shipPrice;
    [SerializeField] private int firstUpgrade;
    [SerializeField] private int upgradeValue;
    [SerializeField] private int upgradePrice;
    //objekti u vezi teksta
    [SerializeField] FormattingNumbers numbers;
    [SerializeField] TMP_Text priceText;
    [SerializeField] TMP_Text damageText;


    public void LoadData(GameData data)
    {
        data.shipDmg.TryGetValue(id, out shipDmg);
        data.shipPrice.TryGetValue(idPrice, out shipPrice);
    }

    public void SaveData(ref GameData data)
    {
        if(data.shipDmg.ContainsKey(id))
        {
            data.shipDmg.Remove(id);
        }
        if(data.shipPrice.ContainsKey(idPrice))
        {
            data.shipPrice.Remove(idPrice);
        }
        data.shipPrice.Add(idPrice, shipPrice);
        data.shipDmg.Add(id, shipDmg);
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        priceText.text = numbers.AbbreviateNumber(shipPrice) + "$";
        damageText.text = numbers.AbbreviateNumber(shipDmg) + "dmg";
        yield return null;

    }

    public int ShipPrice
    {
        get { return shipPrice; }
        set { shipPrice = value;}
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
        FindObjectOfType<AudioMangaer>().Play("firstUpgrade");
    }
}