

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    // Public properties
    public GameObject world;
    public float gravity = 9.81f;

    public Material ExitColor, FloorColor, WallColor;

    // Private properties
    private float verticalVelocity;
    private bool falling = true;
    private const float wallAngle = 90.0f;
    private Collision floor, wall;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Frame Count: " + Time.frameCount);

        move();
        // fall();
        // jump();
        // adjustAngle();
    }
    // On collision enter

    /*
    public void OnCollisionEnter(Collision collision)
    {
        
        
        Vector3 colliderNormal = collision.contacts[0].normal;
        Vector3 colliderPosition = collision.contacts[0].point;
        Vector3 colliderWorldPosition = (colliderPosition - world.transform.position);

        // Get contact angle relative to world origin
        float contactAngle = Vector3.Angle(new Vector2(colliderNormal.x, colliderNormal.y),
                                            new Vector2(this.transform.position.x, this.transform.position.y));

        if (contactAngle < 45)
        {
            // Collider is floor
            floor = collision;
            falling = false;
            verticalVelocity = 0;

            collision.gameObject.GetComponent<MeshRenderer>().material = FloorColor;
            Debug.Log("entered " + collision.gameObject.name + " as floor");
        }
        else
        {
            // Collider is wall
            wall = collision;

            collision.gameObject.GetComponent<MeshRenderer>().material = WallColor;
            Debug.Log("entered " + collision.gameObject.name + " as wall");
        }
    }
    */

        /*
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<MeshRenderer>().material = ExitColor;
        Debug.Log("exited " + collision.gameObject.name);

        if (floor != null)
        {
            if (collision.gameObject == floor.gameObject) {
                floor = null;
                falling = true;
            }            
        }

        if (wall != null)
        {
            if (collision.gameObject == wall.gameObject) { wall = null; }
            Debug.Log("wall set to null");
        }
    }
    */
    
    /*
    void movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        
        if (wall != null)
        {
            Debug.Log("there is a wall to either side");
            float playerWorldAngle = Vector3.Dot(this.gameObject.transform.position, Vector3.up);
            float playerWallAngle = Vector3.Dot(wall.contacts[0].point, Vector3.up);

            if (playerWorldAngle < playerWallAngle && horizontalMovement < 0)
            {
                Debug.Log("wall is on the left");
            }
            else if (playerWorldAngle > playerWallAngle && horizontalMovement > 0)
            {
                Debug.Log("wall is on the right");
            }
            else
            {
                move(horizontalMovement);
            }
        }
        else
        {
        
            move(horizontalMovement);
         }
         
    }
    */

    void move() {

        float horizontalMovement = Input.GetAxis("Horizontal");

        Rigidbody rb = GetComponent<Rigidbody>();

        Debug.Log("horizontal movement axis is: "+horizontalMovement);
        Debug.Log("RigidBody rb is: " + rb);


        rb.AddRelativeForce(0,horizontalMovement * 10,0);

        //this.gameObject.transform.RotateAround(world.transform.position, Vector3.forward, -horizontalMovement * 35 * Time.deltaTime);
    }
    void onCollisionStay(Collider other)
    {

    }

    /*
    void adjustAngle()
    {
        if (floor != null)
        {
            this.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, this.transform.position);
        }
    }
    */

        /*
    Vector3 fallAttempt()
    {
        Vector3 retTransform = Vector3.zero;

        if (falling)
        {

            Vector3 origin = world.transform.position;
            Vector3 playerPosition = this.transform.position;
            Vector3 direction = Vector3.Normalize(origin - playerPosition);

            if (verticalVelocity < 50) { verticalVelocity += gravity; }

            retTransform = direction * verticalVelocity * Time.deltaTime;
        }
        return retTransform;
    }

    void fall()
    {
        this.transform.Translate(fallAttempt(), Space.World);
    }
    */
    void jump()
    {
        if (Input.GetButtonDown("Jump") && !falling)
        {
            verticalVelocity = -10;
            falling = true;
        }
    }
}

