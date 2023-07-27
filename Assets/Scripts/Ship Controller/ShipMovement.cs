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
    // Start is called before the first frame update
    private void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        SpaceshipMovement();
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
}
