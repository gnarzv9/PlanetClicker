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

    //test za shipove
    public SerializableDictionary<string, int> shipDmg;
    public SerializableDictionary<string, int> shipPrice;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to Load
    public GameData()
    {
        this.rebirthResource = 0;
        this.preRebirthResource = 0;
        this.planetNum = 1;
        shipDmg = new SerializableDictionary<string, int>();
        shipPrice = new SerializableDictionary<string, int>();
        this.upgradePrice1 = 500;
        this.upgradePrice2 = 500;
        this.upgradePrice3 = 500;
    }
}
