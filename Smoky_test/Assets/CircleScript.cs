using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public GameObject LArm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LArm.GetComponent<LevelArmScript>().L == true)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime*2);
        }
        if (LArm.GetComponent<LevelArmScript>().R == true)
        {
            transform.Rotate(Vector3.back * Time.deltaTime*2);
        }
        
    }
}
