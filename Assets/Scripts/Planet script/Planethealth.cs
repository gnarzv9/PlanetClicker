using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;

public class Planethealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100000;
    [SerializeField] private int currentHealth;
    public HealthBar healthBar;
    public Game game;
    private int interval = 1;
    float nextTime = 0;
    public FormattingNumbers numbers;
    [SerializeField] private TMP_Text TextHealth;
    //resursi po dmgu
    [SerializeField] private ResourcePerDmg damage;

    public int MaxHealth
    { get { return maxHealth; }
      set { maxHealth = value; } }

    public int CurrentHealth
    {   get { return currentHealth; }
        set { currentHealth = value; } }

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
            TakeDamage((int)(damage.Dmg * game.GetAutomaticPower()));
            nextTime += interval;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth); 
    }
}
