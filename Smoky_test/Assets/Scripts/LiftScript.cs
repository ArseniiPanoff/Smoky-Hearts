using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    public float speed = 0.00001f;
    public float high = 0;
    private float posX;
    private float posY;
    public bool goUp = true;

    void Start()
    {
        posX = gameObject.transform.position.x;
        posY = gameObject.transform.position.y; 
    }
    private void FixedUpdate()
    {
            if (gameObject.transform.position.y >= posY + high)
                goUp = false;
            if (gameObject.transform.position.y <= posY)
                goUp = true;
            if (gameObject.transform.position.y < posY + high && goUp)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed, 0);
            else if(!goUp && gameObject.transform.position.y > posY)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed, 0);
    }
}
