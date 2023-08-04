using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ShipMovement hpNeeded;
    [SerializeField] private BossAttack bossHp;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject Panel;


    private void Update()
    {
        if(bossHp.bossHealth <= 0 || hpNeeded.shipHealth <= 0)
        {
            Panel.SetActive(true);
            joystick.SetActive(false);
            boss.SetActive(false);
        }
    }



    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
