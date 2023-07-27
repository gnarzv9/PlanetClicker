using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStayInside : MonoBehaviour
{
  void Update(){
    transform.position=new Vector3(Mathf.Clamp(transform.position.x,-2.2f,2.2f),Mathf.Clamp(transform.position.y,3.0f,4.0f),transform.position.z);
   }
}
