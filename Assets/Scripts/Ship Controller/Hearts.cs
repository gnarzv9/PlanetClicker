using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
   [SerializeField]
   private ShipMovement health;
   public int numOfHearts=5;

    public Image[] hearts;
   public Sprite Hp;
   public Sprite lostHp;
    


   void Update(){

        if(health.shipHealth>numOfHearts){
            health.shipHealth=numOfHearts;    
        }
       
        for (int i=0; i<hearts.Length; i++){

            if(i<health.shipHealth){
                hearts[i].sprite=Hp;
            }else{
                hearts[i].sprite=lostHp;
            }

            if(i<numOfHearts){
                hearts[i].enabled=true;
            }else{
                hearts[i].enabled=false;
            }
        }
   }
}
