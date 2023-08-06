using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
        [SerializeField]
        private float speed=3f;
        [SerializeField]
        private float movementX;
        [SerializeField]
        private float movementY;
        [SerializeField]
        public int shipHealth=5;
        private SpriteRenderer sr;
        [SerializeField]
        private Rigidbody2D shipRB;

        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private Transform firingPoint;
        [Range(0.1f,1f)]
        [SerializeField]
        private float fireRate=0.7f;

        private float fireTimer;

        public Joystick joystick;

        [SerializeField]
        private BossAttack boss;

    [SerializeField] GameObject ship;

    void Update()
    {
        SpaceshipMovement();

        if(fireTimer<=0f && boss.bossHealth>0){
            Shoot();
            fireTimer=fireRate; 
        }else{
            fireTimer-=Time.deltaTime;
        }
    }

    void SpaceshipMovement(){

        movementX=joystick.Horizontal;
        transform.position+= new Vector3(movementX,0f,0f)*Time.deltaTime*speed;  
        movementY=joystick.Vertical;
        transform.position+= new Vector3(0f,movementY,0f)*Time.deltaTime*speed;
    }

    private void FixedUpdate(){
        shipRB.velocity= new Vector2(movementX,movementY).normalized*speed;
    }

    public void Shoot(){
        Instantiate(bulletPrefab, firingPoint.position,firingPoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("BulletEnemy")){
            shipHealth--;
            Destroy(other.gameObject);
        }
        if(shipHealth==0){
            Destroy(other.gameObject);
            ship.SetActive(false);
            //Destroy(gameObject);
        }
    } 
}
