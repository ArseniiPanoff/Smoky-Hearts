using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BalconyScript : MonoBehaviour
{
    public Rigidbody2D rb;

    //public HingeJoint2D balconyHinge;
    //public JointMotor2D balconyMotor;
    // public float balconyHingeVelocity;
    
    bool playerOnBalcony;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        //balconyHinge = GetComponent<HingeJoint2D>();
        //balconyMotor = balconyHinge.motor;

        //playerOnBalcony = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints2D.None;
            //rb.AddForce(-transform.forward * 10000);
            //playerOnBalcony = true;
        }

    }

    //void OnTriggerExit2D(Collider2D col)
   // {
      //  if (col.gameObject.tag == "Player")
       // { 
       //     rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //playerOnBalcony = false;
      //  }
    //}

}
