using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    GameObject world;
    public float gravityStrength;
    Rigidbody rb;
    public Vector3 fallingDirection;

    Collision floor;

    public Material floorColor;

	// Use this for initialization
	void Start () {
        world = GameObject.FindWithTag("World");
        Debug.Log("world is set to " + world.gameObject.name + ".");

        Debug.Log("gravity is set to "+gravityStrength);
    }
	
	// Update is called once per frame
	void Update () {
        fall();
   
    }


    void fall()
    {
        rb = GetComponent<Rigidbody>();

        fallingDirection = new Vector3(world.transform.position.x - this.transform.position.x, world.transform.position.y - this.transform.position.y, 0);
        
        rb.AddForce(fallingDirection.normalized.x * gravityStrength, fallingDirection.normalized.y * gravityStrength,0);


        
    }


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

            collision.gameObject.GetComponent<MeshRenderer>().material = floorColor;
            Debug.Log("entered " + collision.gameObject.name + " as floor");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exited " + collision.gameObject.name);

        if (floor != null)
        {
            if (collision.gameObject == floor.gameObject)
            {
                floor = null;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (floor == collision)
        {
            floor = collision;
        }
        
    }


    

    }
