using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;


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

    private static readonly SortedDictionary<int, string> abbrevations = new SortedDictionary<int, string>
    {
        {1000,"K"},
        {1000000, "M" },
        {1000000000, "B" }
    };

    public static string AbbreviateNumber(float number)
    {
        for (int i = abbrevations.Count - 1; i >= 0; i--)
        {
            KeyValuePair<int, string> pair = abbrevations.ElementAt(i);
            if (Mathf.Abs(number) >= pair.Key)
            {
                float roundedNumber = number / pair.Key;
                return roundedNumber.ToString("#.##") + pair.Value;
            }
        }
        return number.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("resources")){
         resources=PlayerPrefs.GetInt("resources");
         resourcesText.text=AbbreviateNumber(resources);
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
        resourcesText.text= AbbreviateNumber(resources);
    }

    private IEnumerator GetResourcesAutomatically(){
        resources+=autoResourcesMultiplier;
        PlayerPrefs.SetInt("resources",resources);
        resourcesText.text= AbbreviateNumber(resources);
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
                resourcesText.text= AbbreviateNumber(resources);
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
