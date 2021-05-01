using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] int _ballSpeed;

    public static BallManager Instance { get; private set; } //Singleton pattern
    public static int BallCount { get; set; }
    
    public bool _ballSetup;

    private List<GameObject> ballsInScene = new List<GameObject>();
    private Vector2 _ballVelocity;

    private void Awake()
    {
        if (Instance == null) //If this code is running for the first time
        {
            Instance = this; //Set this (BallManager) to the Instance property
        }
        else {
            Destroy(gameObject); //If a duplicate gets created somehow, destroy it
        }

        //Cache
        _ballVelocity = new Vector2(_ballSpeed, _ballSpeed);
    }


    internal void ChangeBallCount(int i)
    {
        BallCount += i;
    }

    internal void SpawnBall(Vector2 position)
    {

        //If the multiball powerup is picked up below the transform of the Player
        if (position.y <= -6.2f)
        {
            //Instantiate a new ball roughly at the Player's transform
            GameObject newBallFix = Instantiate(_ballPrefab, new Vector2(position.x, position.y + 0.2f), Quaternion.identity);

            //Set its velocity
            newBallFix.GetComponent<Rigidbody2D>().velocity = new Vector2(_ballSpeed, _ballSpeed);

            //Add it to the list of balls
            ballsInScene.Add(newBallFix);

            //Add to the ball counter
            ChangeBallCount(1);

            return;
        }

        //Instantiate a new ball
        GameObject newBall = Instantiate(_ballPrefab, new Vector2(position.x, position.y), Quaternion.identity);

        //Set its velocity
        newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(_ballSpeed, _ballSpeed);

        //Add it to the list of balls
        ballsInScene.Add(newBall);

        //Add to the ball counter
        ChangeBallCount(1);
    }
    public void DestroyBall(Collider2D col)
    {
        //If the colliding game object matches one of the spawned balls in the list
        if (ballsInScene.Count > 0)
        {
            foreach (GameObject ball in ballsInScene.ToList())
            {
                if (col.gameObject == ball)
                {
                    ballsInScene.Remove(ball); //Remove it from the list
                    Destroy(ball);  //Destroy the game object
                }
            }
        }
        else
        {
            ResetBall();
        }
    }

    public void ResetBall()
    {
        GameObject ball = ballsInScene[0];
        _ballSetup = true;
        ball.GetComponent<Rigidbody2D>().transform.SetParent(Player.transform);
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        ball.GetComponent<Rigidbody2D>().transform.localPosition = new Vector2(0, 0.3f);
        ball.GetComponent<Rigidbody2D>().velocity = _ballVelocity;

        //Disable the particle trail on the ball
        ball.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void ShootBall()
    {
        GameObject ball = ballsInScene[0];
        //Shoot the ball at starting set velocity, detach it from the paddle
        _ballSetup = false;
        ball.GetComponent<Rigidbody2D>().transform.SetParent(null);
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        ball.GetComponent<Rigidbody2D>().velocity = _ballVelocity;

        //Enable the particle trail on the ball
        ball.transform.GetChild(0).gameObject.SetActive(true);
    }

    internal void ClearBallList()
    {
        ballsInScene.Clear();
    }
}
