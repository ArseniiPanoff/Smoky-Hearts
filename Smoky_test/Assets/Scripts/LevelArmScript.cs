using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArmScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private float PlayerX;
    private float PlayerY;
    public bool Pressed;
    public Animator _anim;
    public float distanceY;
    public float distanceX;
    public bool L;
    public bool R;
    public bool insidethatloop = false; 
    void Start()
    {
        _anim = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        L = _anim.GetBool("Left");
        R = _anim.GetBool("Right");
        distanceX = Math.Abs(PlayerX - transform.position.x);
        distanceY = Math.Abs(PlayerY - transform.position.y);
        PlayerX = Player.transform.position.x;
        PlayerY = Player.transform.position.y;
        // Player is on the left
        if (distanceX < 3 && Math.Abs(PlayerY - transform.position.y) < 5 && PlayerX < transform.position.x)
        {
            insidethatloop = true;
            if (Pressed)
            {
                _anim.SetBool("Left", false);
                _anim.SetBool("Right", true);
            }
        }
        // Player is on the right
        else if (distanceX < 3 && Math.Abs(PlayerY - transform.position.y) < 5 && PlayerX > transform.position.x)
        {
            insidethatloop = true;
            if (Pressed)
            {
                _anim.SetBool("Right", false);
                _anim.SetBool("Left", true);
            }
        }
        else insidethatloop = false;
    }
}
