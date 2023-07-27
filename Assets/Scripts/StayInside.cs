using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
   void Update(){
    transform.position=new Vector3(Mathf.Clamp(transform.position.x,-1.4f,3f),Mathf.Clamp(transform.position.y,-4f,-1f),transform.position.z);
   }
}
