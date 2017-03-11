using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject Player;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = Player.transform.position, camPos = this.transform.position;

        Vector3 distToMove = 0.1f * (playerPos - camPos);

         distToMove = new Vector3(distToMove.x * distToMove.x, distToMove.y * distToMove.y, 0);

        this.transform.Translate(distToMove, Space.World);
        this.transform.rotation = Player.transform.rotation;


	}
}
