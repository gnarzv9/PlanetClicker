using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform target;
    public float speed=3f;
    public float rotateSpeed=0.015f;
    [SerializeField]
    private Rigidbody2D rb;
    public float distanceToStop=3f;
    public float distanceToShoot=6f;
    public float fireRate=0.5f;
    private float timeToFire;
    public Transform firingPoint;

    private void start(){
        rb=GetComponent<Rigidbody2D>();
        timeToFire=fireRate;
    }
    private void Update(){
        if(!target){
            GetTarget();
        }else{
            RotateTowardsTarget();
         }

         if (Vector2.Distance(target.position, transform.position)<=distanceToShoot){
            Shoot();
         }
    }

    private void Shoot(){
        if(timeToFire<=0f){
            Debug.Log("Shoot");
            timeToFire=fireRate;  
        }else{
            timeToFire-=Time.deltaTime;
        }
    }

    private void FixedUpdate(){
        if(target!=null){
            if(Vector2.Distance(target.position, transform.position)>=distanceToStop){
                rb.velocity=transform.up*speed;
            }else{
                rb.velocity=Vector2.zero;
            }
        }
    }

    private void RotateTowardsTarget(){
        Vector2 targetDirection=target.position-transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x)*Mathf.Rad2Deg-90f;
        Quaternion q=Quaternion.Euler(new Vector3(0,0,angle));
        transform.localRotation=Quaternion.Slerp(transform.localRotation,q,rotateSpeed);
    }

    private void GetTarget(){
        if(GameObject.FindGameObjectWithTag("Ship")){
            target=GameObject.FindGameObjectWithTag("Ship").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ship")){
            Destroy(other.gameObject);
            target=null;
        }else if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
