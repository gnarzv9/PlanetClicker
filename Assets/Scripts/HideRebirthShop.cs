using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
   public GameObject panel;

   public void Trigger(){
    if(panel.activeInHierarchy==false){
        panel.SetActive(true);
    }else{
        panel.SetActive(false);
    }
   }
}