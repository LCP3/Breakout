using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform _leftSensor;
    [SerializeField] Transform _rightSensor;
    [SerializeField] Transform _topSensor;
    [SerializeField] Transform _bottomSensor;
    [SerializeField] float _ballSpeed = 1f;
    


    Rigidbody2D _rigidbody2D;
    float _directionX;
    float _directionY;
    private float _collisionX;
    private float _collisionY;
    private Vector2 _mousePosition;
    private Vector2 localPoint;
    private Transform ballTransform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == null)
            return;

        ballTransform = GetComponent<Transform>();

        foreach (ContactPoint2D contact in collision.contacts)
        {
            //print(collision.GetContact(0).point);
            localPoint = ballTransform.InverseTransformPoint(contact.point);
            Debug.Log($"{ballTransform.name} {localPoint}");

            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.green);
        }
        _collisionX = collision.contacts[0].point.x;
        _collisionY = collision.contacts[0].point.y;

        if (_collisionX > 0) 
        {
            _directionX *= -1; //Flip X velocity
        }
        if (_collisionY < 0) 
        {
            _directionY *= -1; //Flip Y velocity
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _directionX = _ballSpeed;
        _directionY = _ballSpeed;
    }

    private void Update()
    {
        //_rigidbody2D.velocity = new Vector2(_directionX, _directionY);
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Set the position of the mouse in the game
        _rigidbody2D.position = _mousePosition; //Set the player's position to the mouse
    }

}
