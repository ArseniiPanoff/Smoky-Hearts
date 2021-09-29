using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeScript : MonoBehaviour
{
    public Rigidbody2D rb;
    //private bool isManholeFrozen = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeAll; //works!
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints2D.None;
         }

    }
    
    
}
