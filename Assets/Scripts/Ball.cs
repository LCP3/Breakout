using System;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _ballSpeed = 1f;

    Transform _transform;
    Rigidbody2D _rigidbody2D;
    float _directionX;
    float _directionY;
    Vector2 _velocity;
    Vector2 _startingVelocity;
    Vector2 lastFrameVelocity;
    AudioSource _audio;

    public GameObject Player;
    public BallManager BallManager;
    public AudioClip[] _audioSources;

    void Start()
    {
        //Cache
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        _directionX = _ballSpeed;
        _directionY = _ballSpeed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && BallManager.Instance._ballSetup == true)
        {
            BallManager.Instance.ShootBall();
        }

        //Store velocity from last frame for calculation purposes
        lastFrameVelocity = _rigidbody2D.velocity;
    }

    private void FixedUpdate()
    {
        //Make sure the speed is always constant
        _rigidbody2D.velocity = _ballSpeed * (_rigidbody2D.velocity.normalized);
    }



    private void OnCollisionEnter2D(Collision2D collision) //On collision
    {
        float x = PaddleAngle(transform.position, collision.transform.position, collision.collider.bounds.size.x);

        if (collision.transform.name == "Player")
        {
            BounceBall(_rigidbody2D, collision.contacts[0].normal, x, collision); //Pass in the angle
        }
        else
        {
            BounceBall(_rigidbody2D, collision.contacts[0].normal, 0, collision);
        }
    }

    private float PaddleAngle(Vector2 ballPos, Vector2 paddlePos, float x)
    {
        return (ballPos.x - paddlePos.x) / x; //Get the relative angle of the ball to the paddle to set a new trajectory
    }

    private void BounceBall(Rigidbody2D rigidbody2D, Vector2 normal, float paddleAngle, Collision2D collision)
    {
        var speed = lastFrameVelocity.magnitude;

        if (paddleAngle == 0) //If we're not hitting the paddle at all
        {
            Vector2 direction = Vector2.Reflect(lastFrameVelocity.normalized, normal); //Reflect at collision's normal with the direction of the last frame's velocity, normalized to decouple velocity from speed.var direction = Vector2.Reflect(lastFrameVelocity.normalized, normal); //Reflect at collision's normal with the direction of the last frame's velocity, normalized to decouple velocity from speed.
            _rigidbody2D.velocity = direction * Mathf.Max(speed, _ballSpeed);
        }

        else if (paddleAngle < -.25)
        {
            //Left side of the paddle hit
            Vector2 direction = new Vector2(paddleAngle, 1).normalized;
            _rigidbody2D.velocity = direction * speed;
        }
        else if (paddleAngle >= -.25 && paddleAngle <= .25)
        {
            //Middle hit
            Vector2 direction = new Vector2(paddleAngle, 1).normalized;
            _rigidbody2D.velocity = direction * speed;
        }
        else if (paddleAngle > -.25)
        {
            //Right hit
            Vector2 direction = new Vector2(paddleAngle, 1).normalized;
            _rigidbody2D.velocity = direction * speed;
        }
        //Play audio based on what the ball hits
        PlayAudio(collision);
    }

    private void PlayAudio(Collision2D collision)
    {
        if (collision.transform.tag == "Brick")
        {
            _audio.clip = _audioSources[0];
            _audio.Play();
        }
        else
        {
            _audio.clip = _audioSources[1];
            _audio.Play();
        }
    }
}