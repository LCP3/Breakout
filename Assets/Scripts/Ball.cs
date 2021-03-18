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

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 hit = -collision.GetContact(0).normal;

        float angle = Vector2.Angle(hit, Vector2.up);
        //Vector3 cross = Vector3.Cross(Vector3.forward, hit);
        RunDebug(collision, hit, angle); //Uncomment for Debug Raycast + Console info


        if (Mathf.Approximately(angle, 180))
        {
            if (hit.y < 0) //Bottom hit
            {
                _directionY *= -1; //Flip Y velocity
                ChangeVelocity();
                print("Hit Bottom");
            }
        }
        else if (Mathf.Approximately(angle, 90))
        {
            if (hit.x > 0)
            {
                _directionX *= -1; //Flip X velocity
                ChangeVelocity();
                print("Hit Right");
            }
            if (hit.x < 0)
            {
                _directionX *= -1; //Flip X velocity
                ChangeVelocity();
                print("Hit Left");
            }

        }
        else if (Mathf.Approximately(angle, 0))
        {
            if (hit.y > 0) //Top hit
            {
                _directionY *= -1; //Flip Y velocity
                ChangeVelocity();
                print("Hit Top");
            }
        }
        else if (angle >= 1 && angle <= 89 || angle >= 91 && angle <= 179) //Corner check
        {
            _directionX *= -1; //Flip X velocity
            _directionY *= -1; //Flip Y velocity
            ChangeVelocity();
            print("Hit Corner");
        }
    }

    private static void RunDebug(Collision2D collision, Vector2 hit, float angle)
    {
        Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.green);// Visualize the contact point
        print($"Hit: {hit}, Hit.x: {hit.x}, Hit.y: {hit.y}");
        print(angle);
        /*print($"Cross: {cross}, Cross.x: {cross.x}, Cross.y: {cross.y}");
        print($"Abs X: {Mathf.Abs(cross.x)} Abs Y: {Mathf.Abs(cross.x)}");
        print($"== check {Mathf.Abs(cross.x) == Mathf.Abs(cross.x)}");*/
    }

    private void ChangeVelocity()
    {
        _rigidbody2D.velocity = new Vector2(_directionX, _directionY);
    }

    // Start is called before the first frame update
    void Start()
    {
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
