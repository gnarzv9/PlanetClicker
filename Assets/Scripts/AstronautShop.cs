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
    public TMP_Text upgradeText1;
    public TMP_Text upgradeText2;
    public TMP_Text upgradeText3;
    public int upgradePrice1;   //cena za upgrejdovanje ResourceMultiplier-a
    public int upgradePrice2;   //cena za upgrejdovanje Automatskog prikupljanja resursa (kolicina)
    public int upgradePrice3;   //cena za upgrejdovanje Automatskog prikupljanja resursa (brzina)

    void Start()
    {
        upgradePrice1 = 500;
        upgradePrice2 = 500;
        upgradePrice3 = 500;
    }

    private void Update()
    {
        upgradeText1.text = "Cost: " + numbers.AbbreviateNumber((float)upgradePrice1);
        upgradeText2.text = "Cost: " + numbers.AbbreviateNumber((float)upgradePrice2);
        upgradeText3.text = "Cost: " + numbers.AbbreviateNumber((float)upgradePrice3);
    }

    public void UpgradeResourceMultiplier()
    {
        if (game.GetResource() >= upgradePrice1) 
        {
            game.setResource(game.GetResource() - upgradePrice1);
            game.setResourceMultiplier(game.GetResourceMultiplier() + 2);
            upgradePrice1 *= 2;
            Debug.Log("usao sam1");
        }
        else
        {
            Debug.Log("nisam usao1");
        }  
    }

    public void UpgradeAutoResourceMultiplier()
    {
        if (game.GetResource() >= upgradePrice2)
        {
            game.setResource(game.GetResource() - upgradePrice2);
            game.SetautoResourcesMultiplier(game.GetautoResourcesMultiplier() + 2);
            upgradePrice2 *= 2;
            Debug.Log("usao sam2");
        }
        else
        {
            Debug.Log("nisam usao2");
        }
    }

    public void UpgradeAutoResourceSpeed()
    {
        if (game.GetResource() >= upgradePrice3)
        {
            game.setResource(game.GetResource() - upgradePrice3);
            game.SetautoResourceSpeed((float)(game.GetautoResourceSpeed() + 0.2));
            upgradePrice3 *= 2;
            Debug.Log("usao sam3");
        }
        else
        {
            Debug.Log("nisam usao3");
        }
    }
}