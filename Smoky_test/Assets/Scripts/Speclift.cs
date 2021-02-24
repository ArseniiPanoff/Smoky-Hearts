using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speclift : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle3;
    public GameObject circle5;
    public float c1, c3, c5;
    public float angle1 = 0, angle3 = 0, angle5 = 0;
    public bool check1 = true, check2 = true;
    public int High = 25; 

    // Update is called once per frame
    void Update()
    {
        if(!check2 || !check2)
        {
            High = 50;
            check1 = GameObject.FindWithTag("Saver").GetComponent<Saver>().checkPoint1;
            check2 = GameObject.FindWithTag("Saver").GetComponent<Saver>().checkPoint2;
        }
        c1 = (int)circle1.transform.rotation.eulerAngles.z;
        c3 = (int)circle3.transform.rotation.eulerAngles.z;
        c5 = (int)circle5.transform.rotation.eulerAngles.z;
        if (Math.Abs((int)circle1.transform.rotation.eulerAngles.z - angle1) <= 3 && Math.Abs((int)circle3.transform.rotation.eulerAngles.z - angle3)<=3 && Math.Abs((int)circle5.transform.rotation.eulerAngles.z - angle5)<=3 && check1 && check2)
        {
            gameObject.GetComponent<LiftScript>().high = High;
        }
    }
}
