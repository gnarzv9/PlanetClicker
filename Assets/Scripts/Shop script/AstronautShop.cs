using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AstronautShop : MonoBehaviour, IDataPresistance
{
    //shop skripta
    [SerializeField] private ResourcePerDmg damage;
    public Game game;
    public FormattingNumbers numbers;
    public TMP_Text upgradeText1;
    public TMP_Text upgradeText2;
    public TMP_Text upgradeText3;
    public RebirthScript rebirth;
    public int upgradePrice1;   //cena za upgrejdovanje ResourceMultiplier-a
    public int upgradePrice2;   //cena za upgrejdovanje Automatskog prikupljanja resursa (kolicina)
    public int upgradePrice3;   //cena za upgrejdovanje Automatskog prikupljanja resursa (brzina)

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        upgradeText1.text = "Cost: " + numbers.AbbreviateNumber(upgradePrice1);
        upgradeText2.text = "Cost: " + numbers.AbbreviateNumber(upgradePrice2);
        upgradeText3.text = "Cost: " + numbers.AbbreviateNumber(upgradePrice3);
        yield return null;
    }

    public void LoadData(GameData data)
    {
        this.upgradePrice1 = data.upgradePrice1;
        this.upgradePrice2 = data.upgradePrice2;
        this.upgradePrice3 = data.upgradePrice3;
    }

    public void SaveData(ref GameData data)
    {
        data.upgradePrice1 = this.upgradePrice1;
        data.upgradePrice2 = this.upgradePrice2;
        data.upgradePrice3 = this.upgradePrice3;
    }
    //povecava scaling dmg i resursa
    public void UpgradeResourceMultiplier()
    {
        if (rebirth.GetRebirthResource() >= upgradePrice1) 
        {
            rebirth.SetRebirthResource(rebirth.GetRebirthResource() - upgradePrice1);
            game.setResourceMultiplier((float)(game.GetResourceMultiplier() + 0.2));
            upgradePrice1 *= 2;
            upgradeText1.text = "Cost: " + numbers.AbbreviateNumber((float)upgradePrice1);
            rebirth.rebirthText.text = numbers.AbbreviateNumber(rebirth.GetRebirthResource());
            Debug.Log("Upgrejdovao sam dugme 1");
        }
        else
        {
            Debug.Log("Nisam upgrejdovao dugme 1");
        }  
    }
    //povecava dmg
    public void UpgradeAutoResourceMultiplier()
    {
        if (rebirth.GetRebirthResource() >= upgradePrice2)
        {
            rebirth.SetRebirthResource(rebirth.GetRebirthResource() - upgradePrice2);
            damage.DmgScaling = (float)(damage.DmgScaling  + 0.1);
            upgradePrice2 *= 2;
            upgradeText2.text = "Cost: " + numbers.AbbreviateNumber((float)upgradePrice2);
            rebirth.rebirthText.text = numbers.AbbreviateNumber(rebirth.GetRebirthResource());
            Debug.Log("Upgrejdovao damage");
        }
        else
        {
            Debug.Log("nisam usao2");
        }
    }

    //dodaje auto resource i njenu brzinu skupjanja
    public void UpgradeAutoResourceSpeed()
    {
        if (rebirth.GetRebirthResource() >= upgradePrice3)
        {
            rebirth.SetRebirthResource(rebirth.GetRebirthResource() - upgradePrice3);
            game.SetautoResourceSpeed((float)(game.GetautoResourceSpeed() + 0.2));
            upgradePrice3 *= 2;
            upgradeText3.text = "Cost: " + numbers.AbbreviateNumber((float)upgradePrice3);
            rebirth.rebirthText.text = numbers.AbbreviateNumber(rebirth.GetRebirthResource());
            Debug.Log("usao sam3");
        }
        else
        {
            Debug.Log("nisam usao3");
        }
    }
}
