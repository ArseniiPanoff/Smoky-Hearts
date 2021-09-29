using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
//using UnityEngine.Random;
//using System.Random;




public class FallingObjectScript : MonoBehaviour
{
    //public static GameObject FallingObject;
    public GameObject FallingObject;
    public GameObject EndGameCanvas;
    public GameObject BalconyObj;



    // Start is called before the first frame update
    void Start()
    {
       // BalconyObj = GameObject.FindWithTag("Balcony"); //.GetComponent<Collider>();
    }

    void Update()
    {
       if (transform.position.y <= -20)
        {
            Destroy(gameObject);
        }

    }

    //DELETE ON COLLISION WITH FLOOR
    void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Manhole")
            {
                Destroy(gameObject);
            }

            if (col.gameObject.tag == "Balcony" || col.gameObject.tag == "Lift")
            {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }


    
        // if (col.gameObject.tag == "Player")
        //{
        //  EndGameCanvas.SetActive(true);
        //}

    }




    /*
    //destroy object after it moves out of screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    */

}
