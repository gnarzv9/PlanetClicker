using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBullets : MonoBehaviour
{
    SpaceShip Ship;
    void MakeBulletVisible()
    {
        if(Ship.gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            GameObject.Find("bullet1").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
