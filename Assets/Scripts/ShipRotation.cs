using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour
{
 
    public Transform Target;
    public float speed;

    void Update()
    {
        transform.RotateAround(Target.position , Vector3.forward,speed*Time.deltaTime);
    }
}
