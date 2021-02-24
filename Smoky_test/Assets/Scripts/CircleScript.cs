using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public GameObject lArm;
    public float angleSaver = 0f;
    private string direction;
    public int anglesaverint; 
    // Update is called once per frame
    void Update()
    {
        if (lArm.GetComponent<LevelArmScript>().L == true)
        {
            angleSaver += Time.deltaTime * 10;
            direction = "left";
            transform.Rotate(Vector3.forward * Time.deltaTime * 10);
        }
        else if (lArm.GetComponent<LevelArmScript>().R == true)
        {
            angleSaver += Time.deltaTime * 10;
            direction = "right";
            transform.Rotate(Vector3.back * Time.deltaTime * 10);
        }
        else
        {
            if (angleSaver < 15 && direction == "left")
            {
                angleSaver += Time.deltaTime * 10;
                transform.Rotate(Vector3.forward * Time.deltaTime * 10);
            }
            if (angleSaver < 15 && direction == "right")
            {
                angleSaver += Time.deltaTime * 10;
                transform.Rotate(Vector3.back * Time.deltaTime * 10);
            }
        }
        if (angleSaver >= 15.1f)
            angleSaver = 0f;
    }
}
