using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public GameObject world;

    public float gravity = 9.81f;

    private float verticalVelocity;

    private bool falling = true;

    private const float wallAngle = 90.0f;

    private Collision floor;
    private Collision wall;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

            fall();

            



        adjustAngle();
        jump();
        movement();
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("onCollisionEnter");

        Vector3 colliderNormal = collision.contacts[0].normal;
        Vector3 colliderPosition = collision.contacts[0].point;
        Vector3 colliderWorldPosition = (colliderPosition - world.transform.position);

        float contactAngle = Vector3.Angle(new Vector2(colliderNormal.x, colliderNormal.y), new Vector2(this.transform.position.x, this.transform.position.y));

        if (contactAngle < 90)
        {
            floor = collision;
            falling = false;
            Debug.Log("floor");
            verticalVelocity = 0;
        }

        else
        {
            wall = collision;
            Debug.Log("wall");
        }

    }

    private void OnCollisionExit(Collision collision)
    {

        Debug.Log("onCollisionExit");

        if (collision.gameObject == floor.gameObject)
        {
            floor = null;
            falling = true;
            Debug.Log("not a floor anymore");
        }

        else if(collision.gameObject == wall.gameObject)
        {
            wall = null;
            
        }
    }

    void movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if(wall != null)
        {
            float playerWorldAngle = Vector3.Dot(this.gameObject.transform.position, Vector3.up);
            float playerWallAngle = Vector3.Dot(wall.contacts[0].point, Vector3.up);

            Debug.Log("playerWallAngle"+playerWallAngle);
            Debug.Log("playerWorldAngle" + playerWorldAngle);
            
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
                this.gameObject.transform.RotateAround(world.transform.position, Vector3.forward, -horizontalMovement * 35 * Time.deltaTime);
            }
        }
        else
        {
            this.gameObject.transform.RotateAround(world.transform.position, Vector3.forward, -horizontalMovement * 35 * Time.deltaTime);
        }
    }


    void onCollisionStay(Collider other)
    {
        


    }

    void adjustAngle()
    {
        if(floor!=null)
        { 
        this.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, this.transform.position);
        }
    }



    void fall()
    {
        Vector3 origin = world.transform.position;
        Vector3 playerPosition = this.transform.position;
        Vector3 direction = Vector3.Normalize(origin - playerPosition);

        if(verticalVelocity < 30 && falling)
        {
            verticalVelocity += gravity;
        }


        this.transform.Translate(direction * verticalVelocity * Time.deltaTime, Space.World);
    }

    void jump()
    {
        

        if(Input.GetButtonDown("Jump") && !falling)
        {
            verticalVelocity -= 10;
        }
    }


}
