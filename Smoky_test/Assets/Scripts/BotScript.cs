using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotScript : MonoBehaviour
{
    public bool canJump;
    public float cameraSize = 0;
    public Vector3 velocity;
    private ParticleSystem _ps;
    public Animator _anim;
    public int maxSpeed = 8;
    public bool iTisGG = false;
    public bool flymode;
    private bool forCoor = true;
    public bool movingL;
    public bool stopMovingL;
    public bool movingR;
    public bool stopMovingR;
    public float initCoorX;
    public float initCoorY;
    public float YY;
    private float _timer;
    public bool itHasAlreadyTurnedL = false;
    private bool itHasAlreadyTurnedR = false;
    public bool In;
    public SpriteRenderer[] children;
    private static readonly int IsJump = Animator.StringToHash("IsJump");
    private static readonly int IsTakeOff = Animator.StringToHash("IsTakeOff");
    private static readonly int IsMover = Animator.StringToHash("IsMover");
    private static readonly int IsDeath = Animator.StringToHash("IsDeath");
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        gameObject.GetComponent<ParticleSystem>().Play ();
        _ps = GetComponent<ParticleSystem>();
        var main = _ps.main;
        _anim = GetComponent<Animator>();
        main.scalingMode = ParticleSystemScalingMode.Shape;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Tutorial")
        {
            forCoor = false;
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 0f);
        velocity.x = (int) gameObject.GetComponent<Rigidbody2D>().velocity.x;

        // Notifiaction
        if (_timer > 5)
        {
            if(gameObject.transform.childCount == 15)
                gameObject.transform.GetChild(14).GetChild(0).GetComponent<Text>().CrossFadeAlpha(0f, 5f, true);
        }

        //if it is the end of a game
        if (!iTisGG)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = false;
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                canJump = false;
                _anim.SetBool(IsJump, true);
                Invoke(nameof(AnimateJump), 0.25f);
            }

            if (Input.GetKey(KeyCode.Space) && !_anim.GetBool(IsJump)) //take off mode
            {
                flymode = true;
            }
            else
            {
                flymode = false;
                _anim.SetBool(IsTakeOff, false);
                gameObject.transform.GetChild(6).GetChild(0).GetComponent<Renderer>().enabled = false;
                gameObject.transform.GetChild(7).GetChild(0).GetComponent<Renderer>().enabled = false;
            }

            if (Input.GetKey(KeyCode.E))
            {
                foreach (GameObject g in GameObject.FindGameObjectsWithTag("LevelArm"))
                {
                    g.GetComponent<LevelArmScript>().Pressed = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                foreach (GameObject g in GameObject.FindGameObjectsWithTag("LevelArm"))
                {
                    g.GetComponent<LevelArmScript>().Pressed = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!itHasAlreadyTurnedL)
                {
                    itHasAlreadyTurnedL = true;
                }
                stopMovingR = true;
                itHasAlreadyTurnedR = false;
                source.Play();
            }

            if (Input.GetKey(KeyCode.A) && !Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.localScale = new Vector3(1f, 1f, 0f);
                gameObject.transform.GetChild(14).GetChild(0).transform.localScale = new Vector3(1f, 1f, 0f);
                _anim.SetBool(IsMover, true);
                movingL = true;
                movingR = false;
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                movingL = false;
                stopMovingL = true;
                source.Stop();
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!itHasAlreadyTurnedR)
                {
                    itHasAlreadyTurnedR = true;
                }
                stopMovingL = true;
                itHasAlreadyTurnedL = false;
                source.Play();
            }

            if (Input.GetKey(KeyCode.D) && !Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.localScale = new Vector3(-1f, 1f, 0f);
                gameObject.transform.GetChild(14).GetChild(0).transform.localScale = new Vector3(1f, 1f, 0f);
                _anim.SetBool(IsMover, true);
                movingR = true;
                movingL = false;
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                source.Stop();
                movingR = false;
                stopMovingR = true;
            }
        }
        else
        {
            _anim.SetBool(IsDeath, true);
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
            source.Stop();
            movingL = false;
            stopMovingL = true;
            movingR = false;
            stopMovingR = true;
        }

        if (forCoor)
        {
            GameObject.FindWithTag("Saver").GetComponent<Saver>().CheckCoorX = gameObject.transform.position.x;
            GameObject.FindWithTag("Saver").GetComponent<Saver>().CheckCoorY = gameObject.transform.position.y;
            forCoor = false;
        }
    }

    private void FixedUpdate()
    {
        if (Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
        {
            if(gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
            else
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
        }
        //controlling

        if (flymode)
        {
            //flymode
            gameObject.transform.GetChild(6).GetChild(0).GetComponent<Renderer>().enabled = true;
            gameObject.transform.GetChild(7).GetChild(0).GetComponent<Renderer>().enabled = true;
            _anim.SetBool(IsTakeOff, true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1f), ForceMode2D.Impulse);
        }
        
        if (movingL && !Input.GetKeyDown(KeyCode.Space)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3f,0), ForceMode2D.Impulse);
        }
        else if(stopMovingL)
        {
            if (canJump)
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
        
        
        if (movingR && !Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f,0), ForceMode2D.Impulse);
        }
        else if(stopMovingR)
        {
            if (canJump)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x/4, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x/2, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
            }
            _anim.SetBool(IsMover,false);
            stopMovingR = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)//land
   {
       if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Wall"))
       {
           if (!_anim.GetBool(IsJump))
           {
               canJump = true;
           }
           _anim.SetBool(IsTakeOff,false);
       }
   }
    void AnimateJump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,90), ForceMode2D.Impulse);
        _anim.SetBool(IsJump,false);
    }

}
