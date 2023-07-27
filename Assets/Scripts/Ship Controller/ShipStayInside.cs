using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
   void Update(){
    transform.position=new Vector3(Mathf.Clamp(transform.position.x,-2.2f,2.2f),Mathf.Clamp(transform.position.y,-3f,-0.6f),transform.position.z);
   }
}
