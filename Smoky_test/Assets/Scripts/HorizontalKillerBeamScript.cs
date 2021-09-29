using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalKillerBeamScript : MonoBehaviour

{
    public float speed = 0.2f;
    public float beamMove = 20;
    private float posX;
    private float posY;
    public bool AnnasChoiceWhereMoveRight = true;
    public bool moveRight = true;

    void Start()
    {
        posX = gameObject.transform.position.x; //initial = //current
        posY = gameObject.transform.position.y; //initial
    }

    // Update() is called once per frame
    private void Update(){  
    }

    private void FixedUpdate()
    {
        if (AnnasChoiceWhereMoveRight)
        {
            if (gameObject.transform.position.x >= posX + beamMove)
                moveRight = false;
            if (gameObject.transform.position.x <= posX)
                moveRight = true;
            if (gameObject.transform.position.x < posX + beamMove && moveRight)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, gameObject.transform.position.y, 0);
            else if (gameObject.transform.position.x > posX && !moveRight)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed, gameObject.transform.position.y, 0);
        }
        else
        {
            if (gameObject.transform.position.x <= posX - beamMove)
                moveRight = true;
            if (gameObject.transform.position.x >= posX)
                moveRight = false;
            if (gameObject.transform.position.x > posX - beamMove && !moveRight)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed, gameObject.transform.position.y, 0);
            else if (gameObject.transform.position.x < posX && moveRight)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, gameObject.transform.position.y, 0);
        }
    }
}
