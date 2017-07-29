using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam1 : Weapons {

    

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	override protected void fire()
    {
        GameObject newBeam = (GameObject)Instantiate(Resources.Load("Beam"));

        newBeam.GetComponent<BeamRenderer>().start = player.gameObject.transform.position;
        newBeam.GetComponent<BeamRenderer>().end = mouseToWorld;

        newBeam.GetComponent<BeamRenderer>().duration = 2.0f;
    }
}
