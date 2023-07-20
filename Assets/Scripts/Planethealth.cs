using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;

public class Planethealth : MonoBehaviour
{
    public int maxHealth = 100000;
    public int currentHealth;
    public HealthBar healthBar;
    public Game game;
    private int interval = 1;
    float nextTime = 0;
    public FormattingNumbers numbers;

    [SerializeField] private TMP_Text TextHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        TextHealth.text = numbers.AbbreviateNumber(currentHealth) + "\\" + numbers.AbbreviateNumber(maxHealth);
    }

    // Update is called once per frame 
    void Update()   //AutoDmgSkidanje
    {
        TextHealth.text = numbers.AbbreviateNumber(currentHealth) + "\\" + numbers.AbbreviateNumber(maxHealth);
        if (Time.time >= nextTime)  //if napravljen da radi dmg po sekundi
        {
            TakeDamage((int)(game.GetautoResourcesMultiplier() * game.GetautoResourceSpeed()));
            nextTime += interval;
        }
    }

    void OnMouseDown()  //SkidanjeDmgPoKliku
    {
        TakeDamage(game.GetResourceMultiplier());
        Debug.Log("Usao sam");
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth); 
    }
}
