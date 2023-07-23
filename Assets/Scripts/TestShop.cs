using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShop : MonoBehaviour
{
    [SerializeField] private List<SpaceShip> spaceShips = new List<SpaceShip>();
    [SerializeField] private Game game;

    public List<SpaceShip> SpaceShips
    {
        get { return spaceShips; }
    }

    public void UpgradeShip(int index)
    {
        SpaceShip ship = spaceShips[index];
        if(ship.ShipPrice <= game.GetResource())
        {
            if (!ship.gameObject.activeSelf)
            {
                ship.FirstUpgrade();
                ship.gameObject.SetActive(true);
                game.setResource(game.GetResource() - ship.ShipPrice);
            }
            else
            {
                game.setResource(game.GetResource() - ship.ShipPrice);
                ship.Upgrade();
            }
        }
    }
}
