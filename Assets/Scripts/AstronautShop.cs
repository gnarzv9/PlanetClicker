using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AstronautShop : MonoBehaviour
{
    //shop skripta

    public Game game;
    public FormattingNumbers numbers;
    public TMP_Text upgradeText;
    public int upgradePrice;

    void Start()
    {
        upgradePrice = 500;
    }

    private void Update()
    {
        upgradeText.text = "Cost: " + numbers.AbbreviateNumber((float)upgradePrice);
    }

    public void UpgradeResourceMultiplier()
    {
        if (game.GetResource() >= upgradePrice) 
        {
            game.setResource(game.GetResource() - upgradePrice);
            game.setResourceMultiplier(game.GetResourceMultiplier() + 2);
            upgradePrice *= 2;
            Debug.Log("usao sam");
        }
        else
        {
            Debug.Log("nisam usao");
        }
            
    }
}
