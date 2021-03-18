using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _ballSpeed = 1f;

    Rigidbody2D _rigidbody2D;
    float _directionX;
    float _directionY;
    private float _crossX;
    private float _crossY;
    private Vector2 _mousePosition;
    private Vector2 localPoint;
    private Transform _ballTransform;

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == null)
            return;

        localPoint = _ballTransform.InverseTransformPoint(collision.GetContact(0).point); // Getting the point of collision
        Debug.Log($"{_ballTransform.name} {localPoint}"); //Ideally returning an X *or* a Y, e.g. {1,0} or {0,-1}


        _collisionX = Mathf.Round(localPoint.x * 10) / 10; //Rounding collision points to nearest tenth
        _collisionY = Mathf.Round(localPoint.y * 10) / 10;
            
        Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.green);// Visualize the contact point
        

        Debug.Log(_collisionX);
        Debug.Log(_collisionY);

        if (_collisionX != 0) 
        {
            _directionX *= -1; //Flip X velocity
            _rigidbody2D.velocity = new Vector2(_directionX, _directionY).normalized;
        }
        if (_collisionY != 0) 
        {
            _directionY *= -1; //Flip Y velocity
            _rigidbody2D.velocity = new Vector2(_directionX, _directionY).normalized;
        }

    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 hit = collision.GetContact(0).normal;

        float angle = Vector2.Angle(hit, Vector2.up);
        Vector3 cross = Vector3.Cross(Vector3.forward, hit);
        Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.green);// Visualize the contact point
        //ConsoleDebug(hit, angle, cross);
        _crossX = Mathf.Round(cross.x * 10) / 10; //Rounding collision points to nearest tenth
        _crossY = Mathf.Round(cross.y * 10) / 10;

        //print($"{_crossX} X, {_crossY} Y");
        if (Mathf.Approximately(angle, 0))
        {
            if (cross.x < 0) //Bottom hit
            {
                _directionY *= -1;
                ChangeVelocity();
                print("Hit Bottom");
            }
        }
        else if (Mathf.Approximately(angle, 90))
        {
            if (cross.y < 0)
            {
                _directionX *= -1; //Flip X velocity
                ChangeVelocity();
                print("Hit Right");
            }
            if (cross.y > 0)
            {
                _directionX *= -1; //Flip X velocity
                ChangeVelocity();
                print("Hit Left");
            }

        }
        else if (Mathf.Approximately(angle, 180))
        {
            if (cross.x > 0) //Top hit
            {
                _directionY *= -1;
                ChangeVelocity();
                print("Hit Top");
            }
        }
        else if (Mathf.Abs(cross.x) == Mathf.Abs(cross.x))
        {
            _directionX *= -1; //Flip X velocity
            _directionY *= -1; //Flip X velocity
            ChangeVelocity();
            print("Hit Corner");
        }
    }

    private static void ConsoleDebug(Vector2 hit, float angle, Vector3 cross)
    {
        print($"Hit: {hit}, Hit.x: {hit.x}, Hit.y: {hit.y}");
        print(angle);
        print($"Cross: {cross}, Cross.x: {cross.x}, Cross.y: {cross.y}");
        print($"Abs X: {Mathf.Abs(cross.x)} Abs Y: {Mathf.Abs(cross.x)}");
        print($"== check {Mathf.Abs(cross.x) == Mathf.Abs(cross.x)}");
    }

    private void ChangeVelocity()
    {
        _rigidbody2D.velocity = new Vector2(_directionX, _directionY);
    }

    // Start is called before the first frame update
    void Start()
    {
        _ballTransform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _directionX = _ballSpeed;
        _directionY = _ballSpeed;
        _rigidbody2D.velocity = new Vector2(_directionX, _directionY);
    }

    private void Update()
    {
      
       //_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Set the position of the mouse in the game
       //_rigidbody2D.position = _mousePosition; //Set the player's position to the mouse
    }

}
