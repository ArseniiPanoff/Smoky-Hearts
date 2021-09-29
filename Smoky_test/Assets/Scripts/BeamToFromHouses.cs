using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamToFromHouses : MonoBehaviour
{ 
public Rigidbody2D rb;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    rb.constraints = RigidbodyConstraints2D.FreezeAll;

}

void OnTriggerStay2D(Collider2D col)
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
