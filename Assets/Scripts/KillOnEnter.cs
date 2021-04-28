using System;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    public GameObject _ball;
    public BallManager BallManager;

    private void Start()
    {
        BallManager.BallCount = 0;
        //Set up the first ball on game start/retry attempts
        if (BallManager.BallCount == 0)
        {
            BallManager.Instance.ClearBallList();
            BallManager.Instance.SpawnBall(new Vector2(1, 1));
            BallManager.Instance.ResetBall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //If the ball enters the "kill zone"
    {
        var Ball = collision.GetComponent<Ball>(); 

        if (Ball == null) //Make sure the collision is a ball
            return;

        if (BallManager.BallCount > 1) //If there's more than one ball on screen
        {
            BallManager.Instance.DestroyBall(collision);
            BallManager.Instance.ChangeBallCount(-1); //Update Ball Count
        }
        else if (BallManager.BallCount == 0 && GameSystems.Lives == 0)
        {
            BallManager.Instance.DestroyBall(collision);
        }
        else
        { //If the last ball dies
            GameSystems.ChangeLives(-1); //Lose a life
            BallManager.Instance.ResetBall(); //Reset the ball to the paddle for a new round
        }
    }
}
