using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpaceships : MonoBehaviour
{

   public GameObject spaceships;

   public void Trigger(){
    if(spaceships.activeInHierarchy==true){
        spaceships.SetActive(false);
    }else{
        spaceships.SetActive(true);
    }
   }
}
