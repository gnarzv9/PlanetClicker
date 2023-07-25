using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnterTheBoss : MonoBehaviour
{
    [SerializeField] private NewPlanetTransition newPl;
    [SerializeField] private GameObject button;

    private void Start()
    {
        GameObject button = GameObject.Find("UISprite");
    }

    public void ShowBossButton()
    {
        if (button != null)
        {
            // Get the Image component from the target GameObject
            Image targetImage = button.GetComponent<Image>();

            // Now you can access and modify the Image component as needed
            if (targetImage != null)
            {
                if (newPl.BossPlanet() == true)
                {

                    Debug.Log("postavio sam dugme");
                    targetImage.enabled = true;
                }
            }
        }
    }
}
