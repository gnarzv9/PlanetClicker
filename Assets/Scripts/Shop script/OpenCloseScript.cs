using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseScript : MonoBehaviour
{
    [SerializeField] private GameObject Ships;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject otherButton1;
    [SerializeField] private GameObject otherButton2;
    [SerializeField] private GameObject otherButton3;
    [SerializeField] private GameObject otherButton4;
    [SerializeField] private NewPlanetTransition planet;

    public void OpenShop()
    {
        Ships.SetActive(false);
        Panel.SetActive(true);
        otherButton1.SetActive(false);
        otherButton2.SetActive(false);
        otherButton3.SetActive(false);
        otherButton4.SetActive(true);
        FindObjectOfType<AudioMangaer>().Play("buttonclick");
    }

    public void CloseShop()
    {
        Ships.SetActive(true);
        Panel.SetActive(false);
        if (planet.BossPlanet())
            otherButton1.SetActive(true);
        else { otherButton1.SetActive(false); }
        otherButton2.SetActive(true);
        otherButton3.SetActive(true);
        otherButton4.SetActive(false);
        FindObjectOfType<AudioMangaer>().Play("buttonclick");
    }



}
