using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PanelScript : MonoBehaviour
{
    [SerializeField] private ShipMovement hpNeeded;
    [SerializeField] private BossAttack bossHp;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject Panel;

    //pozvana metoda
    private bool hasBeenCalled = false;

    //vreme
    private GameManager gameManager;

    //textovi
    [SerializeField] private TMP_Text result;
    [SerializeField] private TMP_Text outcome;
    [SerializeField] private TMP_Text timeScore;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OverTime = (int)(gameManager.TimeLimit);
    }


    private void Update()
    {
        float elapsedTime = gameManager.GetElapsedTime();
        if(bossHp.bossHealth <= 0 || hpNeeded.shipHealth <= 0 || gameManager.OverTime == 0)
        {
            Panel.SetActive(true);
            joystick.SetActive(false);
            if(!hasBeenCalled)
            {
                BossText();
                if(boss!=null)
                    boss.SetActive(false);
            }

        }
        else { gameManager.TimeText(); }
    }

    public void BossText()
    {
        if(bossHp !=null)
        {
            if (bossHp.bossHealth <= 0)
            {
                result.text = "Victory";
                outcome.text = "you killed the boss";
                timeScore.text = "time left: " + gameManager.OverTime + "s";
                Debug.Log("Ubio sam bosa");
            }
        }


        if(hpNeeded.shipHealth <=0)
        {
            result.text = "Defeat";
            outcome.text = "boss killed you try better next time";
            timeScore.text = "time left: " + gameManager.OverTime + "s";
        }
        else if (gameManager.OverTime == 0)
        {
            result.text = "Defeat";
            outcome.text = "Your time ran out";
            timeScore.text = "time left: " + gameManager.OverTime + "s";
        }
        else
        {
            result.text = "Victory";
            outcome.text = "you killed the boss";
            timeScore.text = "time left: " + gameManager.OverTime + "s";
            Debug.Log("Ubio sam bosa");
        }


        hasBeenCalled = true;
    }


    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        hasBeenCalled = false;
    }

    public void GoHome(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        hasBeenCalled = false;
    }

}
