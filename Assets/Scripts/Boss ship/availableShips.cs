using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class availableShips : MonoBehaviour
{
    [SerializeField] private ProgressShop availableShp;
    [SerializeField] private GameObject[] BossButton;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < availableShp.buttons.Length; i++)
        {
            if (!availableShp.buttons[i].activeSelf)
            {
                BossButton[i].SetActive(false);
            }
            else
                BossButton[i].SetActive(true);
        }
    }
}
