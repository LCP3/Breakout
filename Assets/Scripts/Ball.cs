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

    void Start()
    {
        
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>(); //Cache
        _directionX = _ballSpeed;
        _directionY = _ballSpeed;

        _startingVelocity = new Vector2(_directionX, _directionY); //Set up starting velocity
        _velocity = new Vector2(_directionX, _directionY); //Set up velocity for initial use
        _rigidbody2D.velocity = _startingVelocity; //Set ball's starting velocity
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ballSetup == true)
        {
            ShootBall();
        }
    }

    private void ShootBall()
    {
        //Shoot the ball at starting set velocity, detach it from the paddle
        _ballSetup = false;
        _rigidbody2D.transform.SetParent(null);
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.velocity = _startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) //On collision
    {
        BounceBall(_rigidbody2D, collision.contacts[0].normal);
    }

    private void BounceBall(Rigidbody2D rigidbody2D, Vector2 normal)
    {
        _velocity = Vector2.Reflect(_velocity, normal); //Reflect the current velocity, reflection at contact[0].normal
        _rigidbody2D.velocity = _velocity; //Set new reflected velocity
    }

    public void SetUpBall()
    {
        //Set up the ball with the player paddle
        _ballSetup = true;
        _rigidbody2D.transform.SetParent(Player.transform);
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.transform.localPosition = new Vector2(0, 0.3f);
        _rigidbody2D.velocity = new Vector2(0, 0);

        //Reset stored bounce velocity to initial velocity
        _velocity = _startingVelocity; 
    }
}
