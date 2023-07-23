using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePerDmg : MonoBehaviour
{
    public Game game;
    public int Dmg;
    public SpaceShop spaceShop;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Dmg = spaceShop.DmgShip1 + spaceShop.DmgShip2 + spaceShop.DmgShip3;
       // game.setResource((int)(game.GetResource() * 0.2 * Dmg));
       // Debug.Log(Dmg);
    }

    void DmgPerClick()
    {
        Debug.Log(Dmg);
    }
}
