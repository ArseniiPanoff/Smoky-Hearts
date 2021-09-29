using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftLevel2LEFTScript : MonoBehaviour
{
    public float speed = 0.01f;
    public float high = 20;
    private float posX;
    private float posY;
    private float t;
    public bool goUp = true;
    bool timer = true;
    float T = 0f;

    void Start()
    {
        posX = gameObject.transform.position.x;
        posY = gameObject.transform.position.y;
        t += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (timer)
        {
            T = t;
            timer = false;
        }
        if ((int)t % 2 == 0)
        //while (gameObject.transform.position.y < posY+high)
        {
            if (gameObject.transform.position.y >= posY + high)
                goUp = false;
            if (gameObject.transform.position.y <= posY)
                goUp = true;
            if (gameObject.transform.position.y < posY + high && goUp)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed, 0);
            else if (!goUp && gameObject.transform.position.y > posY)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed, 0);


        }
    }
}
