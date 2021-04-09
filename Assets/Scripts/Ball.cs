using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _ballSpeed = 1f;

    Transform _transform;
    Rigidbody2D _rigidbody2D;
    float _directionX;
    float _directionY;
    private Vector2 _velocity;
    private Vector2 _startingVelocity;

    public GameObject Player;
    bool _ballSetup;
    ParticleSystem _particleSystem;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>(); //Cache
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _directionX = _ballSpeed;
        _directionY = _ballSpeed;

        _startingVelocity = new Vector2(_directionX, _directionY); //Set up starting velocity
        _velocity = new Vector2(_directionX, _directionY); //Set up velocity for initial use
        _rigidbody2D.velocity = _startingVelocity; //Set ball's starting velocity

        if (GameSystems.BallCount >= 1)
            return;

        BallSetup();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ballSetup == true)
        {
            ShootBall();
        }

        print($"Magnitude: {_velocity.magnitude}");
    }

    private void ShootBall()
    {
        //Shoot the ball at starting set velocity, detach it from the paddle
        _ballSetup = false;
        _rigidbody2D.transform.SetParent(null);
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.velocity = _startingVelocity;

        //Enable the particle system on the ball
        _particleSystem.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision) //On collision
    {
        float x = PaddleAngle(transform.position, collision.transform.position, collision.collider.bounds.size.x);
        print($"X: {x}");

        if (collision.transform.name == "Player")
        {
            BounceBall(_rigidbody2D, collision.contacts[0].normal, x);
        }
        else
        {
            BounceBall(_rigidbody2D, collision.contacts[0].normal, 1);
        }
    }

    private float PaddleAngle(Vector2 position1, Vector2 position2, float x)
    {
        return (position1.x - position2.x) / x;
    }

    private void BounceBall(Rigidbody2D rigidbody2D, Vector2 normal, float paddleAngle)
    {
        print($"Velocity 1: {_velocity}");
        _velocity = Vector2.Reflect(_velocity, normal); //Reflect the current velocity, reflection at contact[0].normal
        print($"Velocity 2: {_velocity}");
        _rigidbody2D.velocity = _velocity; //Set new reflected velocity
        

        if (paddleAngle < -.25)
        {
            //-2
            print("-2");
        }
        else if (paddleAngle >= -.25 && paddleAngle <= 0)
        {
            //-1
            print("-1");
        }
        else if (paddleAngle >= 0 && paddleAngle <= .25)
        {
            //1
            print("1");
        }
        else if (paddleAngle > -.25)
        {
            //2
            print("2");
        }
    }

    public void BallSetup()
    {
        //Set up the ball with the player paddle
        _ballSetup = true;
        _rigidbody2D.transform.SetParent(Player.transform);
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.transform.localPosition = new Vector2(0, 0.3f);
        _rigidbody2D.velocity = new Vector2(0, 0);

        //Disable the particle system while the ball is inactive
        _particleSystem.gameObject.SetActive(false);

        //Reset stored bounce velocity to initial velocity
        _velocity = _startingVelocity; 
    }
}
