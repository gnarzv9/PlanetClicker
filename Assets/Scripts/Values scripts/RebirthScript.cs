using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RebirthScript : MonoBehaviour, IDataPresistance
{

    [SerializeField] private int rebirthResource;
    [SerializeField] public TMP_Text rebirthText;
    [SerializeField] private int PreRebirthResource = 0;
    [SerializeField] public TMP_Text PreRebirthText;
    public FormattingNumbers numbers;

    //za shop Rebirth text
    [SerializeField] public TMP_Text shopRebirthText;
    [SerializeField] public TMP_Text shopPreRebirthText;

    //public RebirthResource
    //{
    //    set{ rebirthResource = value;}
    //    get{ return rebirthResource;}
    //}

    public void LoadData(GameData data)
    {
        this.rebirthResource = data.rebirthResource;
        this.PreRebirthResource = data.preRebirthResource;
    }

    public void SaveData(ref GameData data)
    {
        data.rebirthResource = this.rebirthResource;
        data.preRebirthResource = this.PreRebirthResource;
    }



    public void setPreRebirthResource(int number)
    {
        PreRebirthResource = number;
    }
    public int GetPreRebirthResource()
    {
        return PreRebirthResource;
    }

    public void SetRebirthResource(int number)
    {
        rebirthResource = number;
    }
    public int GetRebirthResource()
    {
        return rebirthResource;
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        rebirthText.text = numbers.AbbreviateNumber(rebirthResource);
        shopRebirthText.text = numbers.AbbreviateNumber(rebirthResource);
        PreRebirthText.text = numbers.AbbreviateNumber(PreRebirthResource);
        shopPreRebirthText.text = numbers.AbbreviateNumber(PreRebirthResource);
        yield return null;
    }

    public void Reborn()
    {
        rebirthResource += PreRebirthResource;
        PreRebirthResource = 0;
        rebirthText.text = numbers.AbbreviateNumber(rebirthResource);
        PreRebirthText.text = numbers.AbbreviateNumber(PreRebirthResource);
        shopRebirthText.text = numbers.AbbreviateNumber(rebirthResource);
        shopPreRebirthText.text = numbers.AbbreviateNumber(PreRebirthResource);
    }

}
