using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2ButtonLights : MonoBehaviour

    
{
    public bool lightON = false;
    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OncollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            //gameObject.GetComponent<Renderer>().transform.color = Color.yellow;
            lightON = true;
        }
    }


}
