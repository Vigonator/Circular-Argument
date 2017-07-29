using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    protected float range, damage, cycleTime ;
    Vector3 ray;
    protected Vector3 mouseToWorld;
    public int ammo;
    float nextCycle;
    protected GameObject player;


    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
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
        mouseToWorld = Input.mousePosition;
        mouseToWorld = Camera.main.ScreenToWorldPoint(mouseToWorld);
        mouseToWorld.z = player.transform.position.z;

        
    }

    virtual protected void fire()
    {

    }

    protected void onNoAmmo()
    {

    }
}
