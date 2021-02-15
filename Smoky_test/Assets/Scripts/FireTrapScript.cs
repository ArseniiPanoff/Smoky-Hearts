using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapScript : MonoBehaviour
{
    private GameObject player;
    private float T;
    public float intT;
    public bool Flame = false;
    public float TimerT;
    private float posX;
    public GameObject EndGameCanvas;
    public bool colider;
    public GameObject[] g;
    public float Delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        posX = gameObject.transform.position.x;
        T = -Delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Flame && Math.Abs(player.transform.position.x - posX) < 1)
        {
                player.GetComponent<BotScript>().iTisGG = true;
                g = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject i in g)
                {
                    if (i.GetComponent<EnemyScript>() != null)
                        i.GetComponent<EnemyScript>().iTisGG = true;
                    else if (i.GetComponent<OmonScript>() != null)
                        i.GetComponent<OmonScript>().iTisGG = true;
                }
                colider = true;
                EndGameCanvas.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        T += Time.deltaTime;
        intT = (int)T;

        if (intT % 2 == 0 && TimerT != intT)
        {
            TimerT = intT;
            if (Flame)
            {
                gameObject.GetComponent<ParticleSystem>().Stop();
                Flame = false;
            }
            else
            {
                gameObject.GetComponent<ParticleSystem>().Play();
                Flame = true;
            }
        }
    }
}
