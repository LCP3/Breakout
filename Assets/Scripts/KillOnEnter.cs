using System;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    public GameObject _ball;

    private void OnTriggerEnter2D(Collider2D collision) //If the ball enters the "kill zone"
    {
        var Ball = collision.GetComponent<Ball>(); 

        if (Ball == null) //Make sure the collision is a ball
            return;

        print($"Ballcount: {BallManager.BallCount}");

        /*if (BallManager.BallCount > 1) //If there's more than one ball on screen
        {
            Destroy(Ball.gameObject); //Delete the ball that fell past the player
            BallManager.ChangeBallCount(-1); //Update Ball Count
        }
        else { 
            GameSystems.ChangeLives(-1); //Update Ball Count to 0, triggering a life loss
            Ball.BallSetup();
        }*/

        //BallManager.DestroyBall();

        print(collision);
    }
}
