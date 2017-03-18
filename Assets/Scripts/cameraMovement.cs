using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public GameObject Player;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Player.transform.position;
        Vector3 camPos = this.transform.position;

        Vector3 movVector = playerPos - camPos;
        movVector.z = 0;

        float movVectorFac = 0.1f * movVector.sqrMagnitude * Time.deltaTime;
        movVector *= movVectorFac;

        this.transform.Translate(movVector, Space.World);
        this.transform.rotation = Player.transform.rotation;


    }
}
