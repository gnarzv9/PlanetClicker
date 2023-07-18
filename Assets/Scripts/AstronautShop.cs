using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautShop : MonoBehaviour
{
  

    public void Buy(int num){
    if(num=1){
        Game.ResourcesMultiplier=Game.ResourcesMultiplier+2;
        Game.Resources=Game.Resources-100;
    }else if(num=2){
        Game.AutoResourcesMultiplier=Game.AutoResourcesMultiplier+2;
        Game.Resources=Game.Resources-100;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
