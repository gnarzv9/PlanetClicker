using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSceneShips : MonoBehaviour
{
    //nova lista shipova koja prelazi na drugu scenu
    [SerializeField] private List<SpaceShip> ChosenShips = new List<SpaceShip>();
    //svi moguci shipovi
    [SerializeField] private TestShop ShipsToChoose;
    //Izabrani shipovi (njihovi buttoni)
    [SerializeField] private EnterTheBoss ChosenButton;

    public void ShipsPicked()
    {
        for(int i = 0; i < ShipsToChoose.NumberOfShips; i++)
        {
            if (ChosenButton.ClickedOnce[i] == true)
            {
                ChosenShips.Add(ShipsToChoose.SpaceShips[i]);
                Debug.Log("Dodao sam ship: " + ShipsToChoose.SpaceShips[i]);
            }
        }
    }
}
