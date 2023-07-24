using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;


public class Game : MonoBehaviour
{

    [SerializeField] private int resources;
    [SerializeField] private TMP_Text resourcesText;
    [SerializeField] private int resourcesMultiplier = 0;
    [SerializeField] private GameObject clickeffect;
    [SerializeField] private RectTransform buttonPosition;
    [SerializeField] private int autoResourcesMultiplier = 0;
    [SerializeField] private float autoResourceSpeed = 1;

    public TMP_Text ResourcesText
    {
        get {return resourcesText; }
    }

    public FormattingNumbers numbers; //skripta za formatiranje brojeva

    //getteri i setteri
    public void setResourceMultiplier(int number)
    {
        resourcesMultiplier = number;
    }
    public int GetResourceMultiplier()
    {
        return resourcesMultiplier;
    }

    public void setResource(int number)
    {
        resources = number;
    }
    public int GetResource()
    {
        return resources;
    }

    public void SetautoResourcesMultiplier(int number)
    {
        autoResourcesMultiplier = number;
    }
    public int GetautoResourcesMultiplier()
    {
        return autoResourcesMultiplier;
    }

    public void SetautoResourceSpeed(float number)
    {
        autoResourceSpeed = number;
    }
    public float GetautoResourceSpeed()
    {
        return autoResourceSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("resources")){
         resources=PlayerPrefs.GetInt("resources");
         resourcesText.text=numbers.AbbreviateNumber(resources);
        }

        CountResourcesFromOffline();
        StartCoroutine(GetResourcesAutomatically());
    }

    private void EarnResources(){
        Instantiate(clickeffect,buttonPosition.position.normalized, Quaternion.identity);
        resources+= resourcesMultiplier;
        PlayerPrefs.SetInt("resources",resources);
        resourcesText.text= numbers.AbbreviateNumber(resources);

    }

    private IEnumerator GetResourcesAutomatically(){
        resources+=(int)(autoResourcesMultiplier * autoResourceSpeed);
        PlayerPrefs.SetInt("resources",resources);
        resourcesText.text= numbers.AbbreviateNumber(resources);
        yield return new WaitForSeconds(1);
        StartCoroutine(GetResourcesAutomatically());
    }

    private void CountResourcesFromOffline(){
            TimeSpan timeSpan;
            if(PlayerPrefs.HasKey("LastSessionDate")){
                timeSpan=DateTime.Now-DateTime.Parse(PlayerPrefs.GetString("LastSessionDate"));
                Debug.Log($"You haven't been online for {timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds.");
                resources+= (int)(autoResourcesMultiplier * autoResourceSpeed * (int)timeSpan.TotalSeconds);
                PlayerPrefs.SetInt("resources",resources);
                resourcesText.text= numbers.AbbreviateNumber(resources);
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
