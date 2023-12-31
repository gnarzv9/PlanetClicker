using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;


public class Game : MonoBehaviour, IDataPresistance
{

    [SerializeField] private int resources;
    [SerializeField] private TMP_Text resourcesText;
    [SerializeField] private TMP_Text resourcesText2;
    [SerializeField] private float resourcesMultiplier;
    [SerializeField] private GameObject clickeffect;
    [SerializeField] private RectTransform buttonPosition;
    [SerializeField] private float AutomaticPower = 1;
    [SerializeField] private ResourcePerDmg damage;


    public void LoadData(GameData data)
    {
        this.AutomaticPower = data.AutomaticPower;
        this.resourcesMultiplier = data.resourcesMultiplier;
        this.resources = data.resource;

    }

    public void SaveData(ref GameData data)
    {
        data.AutomaticPower = this.AutomaticPower;
        data.resourcesMultiplier = this.resourcesMultiplier;
        data.resource = this.resources;
    }


    public TMP_Text ResourcesText
    {
        get {return resourcesText; }
    }

    public FormattingNumbers numbers; //skripta za formatiranje brojeva

    //getteri i setteri ulepsati ih jednom
    public void setResourceMultiplier(float number)
    {
        resourcesMultiplier = number;
    }
    public float GetResourceMultiplier()
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
    public void SetAutomaticPower(float number)
    {
        AutomaticPower = number;
    }
    public float GetAutomaticPower()
    {
        return AutomaticPower;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("resources")){
         resources=PlayerPrefs.GetInt("resources");
         resourcesText.text=numbers.AbbreviateNumber(resources);
         resourcesText2.text = numbers.AbbreviateNumber(resources);
        }

        CountResourcesFromOffline();
        StartCoroutine(GetResourcesAutomatically());
    }

    //private void EarnResources(){
    //    Instantiate(clickeffect,buttonPosition.position.normalized, Quaternion.identity);
    //    resources+= resourcesMultiplier;
    //    PlayerPrefs.SetInt("resources",resources);
    //    resourcesText.text= numbers.AbbreviateNumber(resources);

    //}

    private IEnumerator GetResourcesAutomatically(){
        resources+=(int)(AutomaticPower * damage.Dmg * resourcesMultiplier);
        resourcesText.text= numbers.AbbreviateNumber(resources);
        resourcesText2.text = numbers.AbbreviateNumber(resources);
        yield return new WaitForSeconds(1);
        StartCoroutine(GetResourcesAutomatically());
    }

    private void CountResourcesFromOffline(){
            TimeSpan timeSpan;
            if(PlayerPrefs.HasKey("LastSessionDate")){
                timeSpan=DateTime.Now-DateTime.Parse(PlayerPrefs.GetString("LastSessionDate"));
                Debug.Log($"You haven't been online for {timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds.");
                resources+= (int)(AutomaticPower * damage.Dmg * resourcesMultiplier * (int)timeSpan.TotalSeconds);
                resourcesText.text= numbers.AbbreviateNumber(resources);
                resourcesText2.text = numbers.AbbreviateNumber(resources);
        }
    }
}
