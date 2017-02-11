using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public GameObject world;

    private float gravity = 9.81f;

    private bool falling = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(falling == true)
        {
            fall();
        }

        this.transform.LookAt(world.transform.position);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, moveHorizontal, 0.0f);
        this.transform.RotateAround(world.transform.position,Vector3.back,moveHorizontal);

        if(moveVertical >0 && falling==false)
        { 
        this.transform.Translate(0.0f, 0.0f, -moveVertical);
        }
    }

    void fall()
    {
        Vector3 origin = world.transform.position;
        Vector3 playerPosition = this.transform.position;
        Vector3 direction = Vector3.Normalize(origin - playerPosition);

        this.transform.Translate(direction * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("World"))
        {

            falling = false;

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("World"))
        {

            falling = true;

        }

    }
}
