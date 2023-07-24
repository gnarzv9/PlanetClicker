using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShop : MonoBehaviour
{
    [SerializeField] private List<SpaceShip> spaceShips = new List<SpaceShip>();
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Game game;

    public int NumberOfShips
    {
        get { return spaceShips.Count; }
    }
    public List<SpaceShip> SpaceShips
    {
        get { return spaceShips; }
    }

    public void UpgradeShip(int index)
    {
        SpaceShip ship = spaceShips[index];
      
        if (ship.ShipPrice <= game.GetResource())
        {
            if (ship.gameObject.GetComponent<SpriteRenderer>().enabled == false) // proverava da li je sprite render ugasen
            {
                ship.FirstUpgrade();
                bullets[index].gameObject.GetComponent<SpriteRenderer>().enabled = true; //puc puc se pojavljuje
                ship.gameObject.GetComponent<SpriteRenderer>().enabled = true;  //brod se pojavljuje
                game.setResource(game.GetResource() - ship.ShipPrice);
                Debug.Log("Prvi put upgrejdovao ship ");
            }
            else
            {
                game.setResource(game.GetResource() - ship.ShipPrice);
                ship.Upgrade();
                Debug.Log("Normalan upgrejd");
            }
        }
    }
}
