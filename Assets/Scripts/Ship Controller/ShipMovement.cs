using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
        [SerializeField]
        private float speed=6f;
        [SerializeField]
        private float movementX;
        [SerializeField]
        private float movementY;

        private SpriteRenderer sr;
        [SerializeField]
        private Rigidbody2D shipRB;

        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private Transform firingPoint;
        [Range(0.1f,1f)]
        [SerializeField]
        private float fireRate=0.5f;

        private float fireTimer;
    

    // Update is called once per frame
    void Update()
    {
        SpaceshipMovement();

        if(Input.GetMouseButtonDown(0) && fireTimer<=0f){
            Shoot();
            fireTimer=fireRate;
        }else{
            fireTimer-=Time.deltaTime;
        }
    }

    void SpaceshipMovement(){

        movementX=Input.GetAxisRaw("Horizontal");
        transform.position+= new Vector3(movementX,0f,0f)*Time.deltaTime*speed;  
        movementY=Input.GetAxisRaw("Vertical");
        transform.position+= new Vector3(0f,movementY,0f)*Time.deltaTime*speed;
    }

    private void FixedUpdate(){
        shipRB.velocity= new Vector2(movementX,movementY).normalized*speed;
    }

    private void Shoot(){
        Instantiate(bulletPrefab, firingPoint.position,Quaternion.identity);
    }
}
