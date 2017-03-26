using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    protected float range, damage, cycleTime ;
    Vector3 ray;
    public int ammo;
    float nextCycle;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        getAim();

        if (Input.GetButton("Fire1") && Time.time > nextCycle)
        {

            if (ammo > 0)
            {
                nextCycle = Time.time + cycleTime;

                fire();
            }
            else
            {
                onNoAmmo();
            }
        }
    }

    private void getAim()
    {
        ray = Input.mousePosition - this.transform.position;
    }

    protected void fire()
    {

    }

    protected void onNoAmmo()
    {

    }
}
