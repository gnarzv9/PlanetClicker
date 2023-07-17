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

        CountResourcesFromOffline();
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

    private void CountResourcesFromOffline(){
            TimeSpan timeSpan;
            if(PlayerPrefs.HasKey("LastSessionDate")){
                timeSpan=DateTime.Now-DateTime.Parse(PlayerPrefs.GetString("LastSessionDate"));
                Debug.Log($"You haven't been online for {timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds.");
                resources+=resourcesMultiplier*(int)timeSpan.TotalSeconds;
                PlayerPrefs.SetInt("resources",resources);
                resourcesText.text=resources.ToString();
            }
    }

    #if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause){
        if (pause)
        PlayerPrefs.SetString("LastSessionDate",DateTime.Now.ToString());
    }

    #else
    private void OnApplicationQuit(){
        PlayerPrefs.SetString("LastSessionDate",DateTime.Now.ToString());
    }
    #endif
}
