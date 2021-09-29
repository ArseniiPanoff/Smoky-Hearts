using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: Instantiate and delete upon collision with floor is not the momst resource efficient method
//Should use Object Pool

public class FallingObjectInstantiate : MonoBehaviour
{
    private float timer = 0.0f;
    private float nextTime;
    public float spawnX;
    public float spawnY;
    //private int whatToSpawn;
    public GameObject FallingObject;
    private Vector3 spawnPosition;

    void Start()
    {
                                                
    }
                                                                            
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextTime)
        {

            // this.spawn();
            spawnY = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(200, 600)).y, Camera.main.ScreenToWorldPoint(new Vector2(400, Screen.height)).y); //x coordinate counts from o of camera square
            spawnX = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(FallingObject, spawnPosition, Quaternion.identity);

            timer = 0.0f;
            nextTime = UnityEngine.Random.Range(1.0f, 2.0f);

        }

    }

    //void spawn()
    //{ 
    
    //}
   
}

