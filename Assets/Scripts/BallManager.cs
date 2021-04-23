using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance { get; private set; } //Singleton pattern
    public static int BallCount { get; private set; }

    public int numOfBalls;
    public GameObject _ballPrefab;
    public GameObject Player;

    [SerializeField]
    private int _ballSpeed;

    public List<GameObject> ballsInScene = new List<GameObject>();


    private void Awake()
    {
        if (Instance == null) //If this code is running for the first time
        {
            Instance = this; //Set this (BallManager) to the instance
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject); //If a duplicate gets created, destroy it
        }
    }

    private void Start()
    {
    }

    internal void ChangeBallCount(int i)
    {
        BallCount += i;
    }

    private void Update()
    {
    }

    internal void SpawnBall(Vector2 position)
    {
        //Instantiate a new ball
        GameObject newBall = Instantiate(_ballPrefab, new Vector2(position.x, position.y), Quaternion.identity);

        //Set its velocity
        newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(_ballSpeed, _ballSpeed);

        //Add it to the list of balls
        ballsInScene.Add(newBall);

        if (BallCount == 0) {
            //Set the ball to the paddle
            newBall.transform.SetParent(Player.transform);
            newBall.GetComponent<Rigidbody2D>().isKinematic = true;
            newBall.GetComponent<Rigidbody2D>().transform.localPosition = new Vector2(0, 0.3f);
            newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(_ballSpeed, _ballSpeed);
        }
    }
}
