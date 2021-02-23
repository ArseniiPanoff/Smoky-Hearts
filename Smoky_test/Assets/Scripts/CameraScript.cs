using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public Transform Player;
    private bool SaverIS = true;
    public Saver Saver;
    private string sceneName;
    private bool isinside = false;
    private float cameraSize;
    public int howMuch = 10;
    private bool isInside4 = false;
    private float i = 0;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Tutorial" || sceneName == "Menu")
        {
            SaverIS = false;
        }
    }
    void Update()
    {
        foreach (var i in GameObject.FindWithTag("Saver").GetComponent<Saver>().level)
        {
            if (gameObject.transform.position.x < i.Xcoor2 && gameObject.transform.position.x > i.Xcoor1 && gameObject.GetComponent<Camera>().orthographicSize != 20)
            {
                isinside = true;
            }
        }
        if (cameraSize < 25 && isinside)
        {
            gameObject.transform.position += new Vector3(0, 0, 0.1f);
            cameraSize = gameObject.transform.position.z;
        }
        else
        {
            if (cameraSize > 14 && !isinside)
            {
                gameObject.transform.position -= new Vector3(0, 0, 0.1f);
                cameraSize = gameObject.transform.position.z;
            }
        }
        if (SceneManager.GetActiveScene().name == "Level4" && Player.transform.position.x > Saver.diapazon.x && Player.transform.position.x < Saver.diapazon.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, Saver.PointOfView, 17f * Time.deltaTime);
            if (!isInside4) 
            { 
                isInside4 = true;
            }
        }
        else
        {
            if (Player.GetComponent<BotScript>().itHasAlreadyTurnedL)
            {
                howMuch = -10;
                if (i > howMuch)
                {
                    i -= 0.2f;
                }
            }
            else
            {
                howMuch = 10;
                if (i < howMuch)
                {
                    i += 0.2f;
                }
            }
            if (isInside4)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x+i, Player.position.y, -14), 30f * Time.deltaTime);
                if ((int)transform.position.x == (int)Player.position.x && (int)transform.position.y == (int)Player.position.y && transform.position.z == -14)
                {
                    isInside4 = false;
                }
            }
            else
            {
                transform.position = new Vector3(Player.position.x + i, Player.position.y, -14);
            }
        }
    }
    private void FixedUpdate()
    {
        
    }
}
