using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public GameObject world;

    public float gravity = 9.81f;

    private Vector2 verticalVelocity;

    private bool falling = true;

    private const float wallAngle = 90.0f;

    private Collision floor;
    private Collision wall;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(falling == true)
        {
            fall();

            

            Debug.Log("onCollisionEnter");
        }

        adjustAngle();

        movement();
    }

    public void OnTriggerEnter(Collision collision)
    {
        Debug.Log("onCollisionEnter");

        Vector3 colliderNormal = collision.contacts[0].normal;
        Vector3 colliderPosition = collision.contacts[0].point;
        Vector3 colliderWorldPosition = (colliderPosition - world.transform.position);

        float contactAngle = Vector3.Angle(new Vector2(colliderNormal.x, colliderNormal.y), new Vector2(colliderNormal.x, colliderNormal.y));

        if (contactAngle < 90)
        {
            floor = collision;
            falling = false;
            Debug.Log("floor");
        }

        else
        {
            wall = collision;
            Debug.Log("wall");
        }

    }

    private void OnTriggerExit(Collision collision)
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

            if(playerWorldAngle > playerWallAngle  )
            {

            }
        }
        else
        {
            this.gameObject.transform.RotateAround(world.transform.position, Vector3.forward, -horizontalMovement * 35 * Time.deltaTime);
        }
    }


    void onTriggerStay(Collider other)
    {
        


    }

    void adjustAngle()
    {
        if(floor!=null)
        { 
        this.gameObject.transform.rotation = Quaternion.LookRotation(floor.contacts[0].point);
        }
    }



    void fall()
    {
        Vector3 origin = world.transform.position;
        Vector3 playerPosition = this.transform.position;
        Vector3 direction = Vector3.Normalize(origin - playerPosition);

        this.transform.Translate(direction * gravity * Time.deltaTime, Space.World);
    }


}
