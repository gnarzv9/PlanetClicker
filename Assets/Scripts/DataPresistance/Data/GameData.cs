using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int rebirthResource;
    public int preRebirthResource;
 //   public int planetNum;


    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to Load
    public GameData()
    {
        this.rebirthResource = 0;
        this.preRebirthResource = 0;
 //       this.planetNum = 1;
    }
}
