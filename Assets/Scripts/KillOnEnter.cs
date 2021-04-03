using System;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //If the ball enters the "kill zone"
    {
        var Ball = collision.GetComponent<Ball>(); //Make sure the collision is a ball

        if (Ball == null)
            return;

        print($"Ballcount: {GameSystems.BallCount}");

        if (GameSystems.BallCount > 1) //If there's more than one ball on screen
        {
            Destroy(Ball.gameObject); //Delete the ball that fell past the player
            GameSystems.ChangeBallCount(-1); //Update Ball Count
        }
        else { 
            GameSystems.ChangeLives(-1); //Update Ball Count to 0, triggering a life loss
            Ball.BallSetup(); //Re-set up the ball
        }
    }
}
