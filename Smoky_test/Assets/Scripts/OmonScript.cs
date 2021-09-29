using System;
using Unity.Mathematics;
using UnityEngine;

public class OmonScript : MonoBehaviour
{
    private bool forCoor = true;
    public bool iTisGG = false;
    public Vector3 velocity;
    private ParticleSystem _ps;
    private Animator _anim;
    public int maxSpeed = 8;
    public float initCoorX;
    public float initCoorY;
    public bool ArmPunch = false;

    public bool movingL = false;
    public bool stopMovingL = false;

    public bool movingR = false;
    public bool stopMovingR = false;
    private float _timer = 0.0f;
    public GameObject player;
    public float playerX;
    public float playerY;
    private Vector3 positionPlayer;
    private Vector3 positionEnemy;
    public float EnemyX;
    public float EnemyY;
    public float distance;
    public bool iSeeU = true;
    private static readonly int IsMover = Animator.StringToHash("IsMover");
    private static readonly int IsTakeOff = Animator.StringToHash("IsTakeOff");
    private static readonly int IsPunch = Animator.StringToHash("IsPunch");
    public float t = 0f;
    public float punchTimer = 0f;
    bool PunchTmerbool = true;
    //private AudioSource source;
    void Start()
    {
        //source = GetComponent<AudioSource>();
        //gameObject.GetComponent<ParticleSystem>().Play();
        //_ps = GetComponent<ParticleSystem>();
        // var main = _ps.main;
        _anim = GetComponent<Animator>();
        //main.scalingMode = ParticleSystemScalingMode.Shape;
    }

    void Update()
    {//в апдейт считать команду
        //в фиксд апдейт выполнить
        t += Time.deltaTime;
        var position = player.transform.position;
        positionPlayer = position;
        playerX = positionPlayer.x;
        playerY = positionPlayer.y;

        positionEnemy = gameObject.transform.position;
        EnemyX = positionEnemy.x;
        EnemyY = positionEnemy.y;
        distance = math.abs(playerX - EnemyX);
        _timer += Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 0f);
        velocity.x = (int)gameObject.GetComponent<Rigidbody2D>().velocity.x;
        if (!iTisGG) // death or not death of main character // if MC is dead, everything stops,  if not game over
        {
            if (t - punchTimer >= 3.45f && !PunchTmerbool)
            {
                _anim.SetBool(IsPunch, false);
                PunchTmerbool = true;
                ArmPunch = false;
                punchTimer = 0;
            }
            else if (math.abs(playerX - EnemyX) < 8f && iSeeU) //punches from 8
            {
                _anim.SetBool(IsPunch, true);
                movingL = false;
                stopMovingR = true;
                stopMovingL = true;
                // source.Stop();
                movingR = false;
                if (PunchTmerbool)
                {
                    ArmPunch = true;
                    _anim.SetBool(IsMover, false);//stop
                    if (playerX < EnemyX)
                        gameObject.transform.localScale = new Vector3(1f, 1f, 0f);//turn
                    else
                        gameObject.transform.localScale = new Vector3(-1f, 1f, 0f);//turn
                    punchTimer = t;
                    PunchTmerbool = false;
                }
            }
            else if (math.abs(playerX - EnemyX) < 20f && playerX < EnemyX && iSeeU && math.abs(playerY - EnemyY) < 20f && !ArmPunch) //Omon sees from 20
            {//playerx <enemyx = player is on the left
                gameObject.transform.localScale = new Vector3(1f, 1f, 0f);
                _anim.SetBool(IsMover, true);
                movingL = true;
                /*if (!source.isPlaying)
                    source.Play();*/
                movingR = false;
                stopMovingR = false;
            }
            else if (math.abs(playerX - EnemyX) >= 20f || !iSeeU)
            {
                _anim.SetBool(IsMover, false);
                _anim.SetBool(IsPunch, false);
                movingL = false;
                stopMovingR = true;
                stopMovingL = true;
               // source.Stop();
                movingR = false;
            }
            else if (math.abs(playerX - EnemyX) < 20f && playerX > EnemyX && iSeeU && math.abs(playerY - EnemyY) < 20f && !ArmPunch)
            {
                gameObject.transform.localScale = new Vector3(-1f, 1f, 0f);
                _anim.SetBool(IsMover, true);
                _anim.SetBool(IsPunch, false);
                movingR = true;
                /*if (!source.isPlaying)
                    source.Play();*/
                movingL = false;
                stopMovingL = false;
            }
        }
        else
        {
            if (t - punchTimer >= 3.45f && !PunchTmerbool)
            {
                _anim.SetBool(IsPunch, false);
                PunchTmerbool = true;
                ArmPunch = false;
                punchTimer = 0;
            }
            _anim.SetBool(IsMover, false);
            //source.Stop();
            movingL = false;
            stopMovingL = true;
            movingR = false;
            stopMovingR = true;
        }
        if (forCoor) //coordinates at start
        {
            initCoorX = EnemyX;
            initCoorY = EnemyY;
            forCoor = false;
        }
    }

    private void FixedUpdate()
    {
        if (movingL)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-2.7f, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
        }
        else if (stopMovingL)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x / 2, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            _anim.SetBool(IsMover, false);
            stopMovingL = false;
        }
        if (movingR)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(2.7f, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
        }
        else if (stopMovingR)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x / 2, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            _anim.SetBool("IsMover", false);
            stopMovingR = false;
        }
        /*if (ArmPunch)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);*/
    }
}
