using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Game : MonoBehaviour
{

    private int resources;
    [SerializeField]
    private TMP_Text resourcesText;
    [SerializeField]
    private int resourcesMultiplier=0;
    [SerializeField] 
    private GameObject clickeffect;
    [SerializeField]
    private RectTransform buttonPosition;
    [SerializeField]
    private int autoResourcesMultiplier=0;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("resources")){
         resources=PlayerPrefs.GetInt("resources");
         resourcesText.text=resources.ToString();
        }

        StartCoroutine(GetResourcesAutomatically());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnResources(){
        Instantiate(clickeffect,buttonPosition.position.normalized, Quaternion.identity);
        resources+= resourcesMultiplier;
        PlayerPrefs.SetInt("resources",resources);
        resourcesText.text=resources.ToString();
    }

    private IEnumerator GetResourcesAutomatically(){
        resources+=autoResourcesMultiplier;
        PlayerPrefs.SetInt("resources",resources);
        resourcesText.text= resources.ToString();
        yield return new WaitForSeconds(1);
        StartCoroutine(GetResourcesAutomatically());
    }

 
}
