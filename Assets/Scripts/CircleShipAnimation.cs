using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShipAnimation : MonoBehaviour
{
    
    private void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            gameObject.transform.Rotate(0f,0f,10f*Time.deltaTime*10f);
        }else if(Input.GetKey(KeyCode.D)){
            gameObject.transform.Rotate(0f,0f,-10f*Time.deltaTime*10f);
        }
    }
}
