using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public GameObject player;
    private float posX;
    private float playerX;
    public float speed = 0.2f;
    private bool MoveRight = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        posX = gameObject.transform.GetChild(0).position.x;
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        if (math.abs(playerX-posX) < 30)
        {
            MoveRight = true;
        }
        else
        {
            MoveRight = false;
        }
    }
    private void FixedUpdate()
    {
        if (MoveRight)
        {
            for (int i = 1; i < 4; i++)
            {
                if (gameObject.transform.GetChild(i).position.x < posX + 20f * i)
                {
                    gameObject.transform.GetChild(i).position = new Vector3(gameObject.transform.GetChild(i).position.x + speed, gameObject.transform.GetChild(i).position.y, 0);
                }
            }
        }
        else
        {
            for (int i = 1; i < 4; i++)
            {
                if (gameObject.transform.GetChild(i).position.x > posX)
                {
                    gameObject.transform.GetChild(i).position = new Vector3(gameObject.transform.GetChild(i).position.x - speed, gameObject.transform.GetChild(i).position.y, 0);
                }
            }
        }
    }
}
