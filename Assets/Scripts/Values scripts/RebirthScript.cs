using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RebirthScript : MonoBehaviour
{

    [SerializeField] private int rebirthResource = 0;
    [SerializeField] public TMP_Text rebirthText;
    [SerializeField] private int PreRebirthResource = 0;
    [SerializeField] public TMP_Text PreRebirthText;
    public FormattingNumbers numbers;

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
    void Start()
    {
        rebirthText.text = numbers.AbbreviateNumber(rebirthResource);
        PreRebirthText.text = numbers.AbbreviateNumber(PreRebirthResource);
    }

    // Update is called once per frame
    void Update()
    {
        rebirthText.text = numbers.AbbreviateNumber(rebirthResource);
        PreRebirthText.text = numbers.AbbreviateNumber(PreRebirthResource);
    }

    public void Reborn()
    {
        rebirthResource = PreRebirthResource;
        PreRebirthResource = 0;
        rebirthText.text = numbers.AbbreviateNumber(rebirthResource);
        PreRebirthText.text = numbers.AbbreviateNumber(PreRebirthResource);
    }


}
