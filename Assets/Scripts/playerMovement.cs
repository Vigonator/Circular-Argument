

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    // Public properties

    // Private properties


    Vector3 worldCenter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            this.GetComponent<Rigidbody>().AddForce(-this.GetComponent<Gravity>().fallingDirection.normalized * 15, ForceMode.Impulse);
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        this.gameObject.transform.RotateAround(worldCenter, Vector3.forward, -horizontalMovement * 35 * Time.deltaTime);

    }

}

