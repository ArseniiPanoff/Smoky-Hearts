using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFromHouses : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.angularDrag = 400f;

    }

    //public float moveSpeed = 50f;

   // void Update()
   //{
        //rb.transform.Rotate(Vector3.up * moveSpeed * Time.deltaTime);

   // }

    //void OnTriggerStay2D(Collider2D col)
    // void OnCollisionStay2D(Collider2D col)     DOESN'T WORK
    //void OnCollisionEnter2D(Collider2D col)        DOESN'T WORK
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            rb.constraints = RigidbodyConstraints2D.None;
        }

    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //  if (col.gameObject.tag == "Player")
    //{
    //  rb.constraints = RigidbodyConstraints2D.FreezeAll;
    //}
    //}

}