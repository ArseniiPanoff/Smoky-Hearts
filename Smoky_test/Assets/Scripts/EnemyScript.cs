using System;
using Unity.Mathematics;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool forCoor = true;
    public bool iTisGG = false;
    public bool _canJump;
    public Vector3 velocity;
    private ParticleSystem _ps;
    private Animator _anim;
    public int maxSpeed = 8;
    public float initCoorX;
    public float initCoorY;
    public bool flymode = false;

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
    private static readonly int IsJump = Animator.StringToHash("IsJump");
    public float t = 0f;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        gameObject.GetComponent<ParticleSystem>().Play();
        _ps = GetComponent<ParticleSystem>();
        var main = _ps.main;
        _anim = GetComponent<Animator>();
        main.scalingMode = ParticleSystemScalingMode.Shape;
    }

    void Update()
    {
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
        if (!iTisGG)
        {

            if (math.abs(playerX - EnemyX) < 14f && playerX < EnemyX && iSeeU && math.abs(playerY - EnemyY) < 14f)
            {
                gameObject.transform.localScale = new Vector3(1f, 1f, 0f);
                _anim.SetBool(IsMover, true);
                movingL = true;
                if (!source.isPlaying)
                    source.Play();
                movingR = false;
                stopMovingR = false;
            }
            else if (math.abs(playerX - EnemyX) >= 14f || !iSeeU)
            {
                movingL = false;
                stopMovingR = true;
                stopMovingL = true;
                source.Stop();
                movingR = false;
            }
            else if (math.abs(playerX - EnemyX) < 14f && playerX > EnemyX && iSeeU && math.abs(playerY - EnemyY) < 14f)
            {
                gameObject.transform.localScale = new Vector3(-1f, 1f, 0f);
                _anim.SetBool(IsMover, true);
                movingR = true;
                if (!source.isPlaying)
                    source.Play();
                movingL = false;
                stopMovingL = false;
            }
        }
        else
        {
            source.Stop();
            movingL = false;
            stopMovingL = true;
            movingR = false;
            stopMovingR = true;
        }
        if(forCoor)
        {
            initCoorX = EnemyX;
            initCoorY = EnemyY;
            forCoor = false;
        }
    }

    private void FixedUpdate()
    {
        /*if (Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
        {
            if(gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
            else
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
        }*/
        //controlling

        if (movingL) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.2f,0), ForceMode2D.Impulse);
        }
        else if(stopMovingL)
        {
            if (_canJump)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x/4, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x/2, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            }
            _anim.SetBool(IsMover,false);
            stopMovingL = false;
        }
        
        
        if (movingR)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.2f,0), ForceMode2D.Impulse);
        }
        else if(stopMovingR)
        {
            if (_canJump)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x/4, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x/2, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            }
            _anim.SetBool("IsMover",false);
            stopMovingR = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)//land
   {
       if (other.gameObject.CompareTag("Floor"))
       {
           if (!_anim.GetBool(IsJump))
           {
               _canJump = true;
           }
           _anim.SetBool(IsTakeOff,false);
       }
   }
    void AnimateJump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,50), ForceMode2D.Impulse);
        _anim.SetBool(IsJump,false);
    }
}
