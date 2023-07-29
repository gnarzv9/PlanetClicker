using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int rebirthResource;
    public int preRebirthResource; 
    public int planetNum;       //broj planete na kojoj je
    public int upgradePrice1;  //cena za upgrejdovanje ResourceMultiplier-a
    public int upgradePrice2;  //cena za upgrejdovanje Automatskog prikupljanja resursa (kolicina)
    public int upgradePrice3;  //cena brzine prikljanja
    public float dmgScaling; //povecavanje dmg po kliku
    public float AutomaticPower = 1;
    public float resourcesMultiplier; // skelovanje resursa i dmga
    public int resource;

    //test za shipove
    public SerializableDictionary<string, int> shipDmg;
    public SerializableDictionary<string, int> shipPrice;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to Load
    public GameData()
    {
        //this.rebirthResource = 0;
        this.preRebirthResource = 0;
        this.planetNum = 1;
        shipDmg = new SerializableDictionary<string, int>();
        shipPrice = new SerializableDictionary<string, int>();
        shipDmg.Add("ship0dmg", 70);
        shipPrice.Add("shipPrice0", 200);
        shipPrice.Add("shipPrice1", 500);
        shipPrice.Add("shipPrice2", 1500);
        shipPrice.Add("shipPrice3", 4500);
        shipPrice.Add("shipPrice4", 10000);
        shipPrice.Add("shipPrice5", 25000);
        shipPrice.Add("shipPrice6", 75000);
        shipPrice.Add("shipPrice7", 100000);
        shipPrice.Add("shipPrice8", 250000);
        shipPrice.Add("shipPrice9", 500000);
        shipPrice.Add("shipPrice10", 1000000);
        shipPrice.Add("shipPrice11", 3000000);
        shipPrice.Add("shipPrice12", 10000000);
        shipPrice.Add("shipPrice13", 50000000);
        shipPrice.Add("shipPrice14", 100000000);
        shipPrice.Add("shipPrice15", 1000000000);

        this.resource = 0;
        this.upgradePrice1 = 500;
        this.upgradePrice2 = 500;
        this.upgradePrice3 = 500;
        this.dmgScaling = 1;
        this.AutomaticPower = 0;
        this.resourcesMultiplier = 0.2f;
    }
}
