using System;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //If the ball enters the "kill zone"
    {
        var Ball = collision.GetComponent<Ball>();

        if (Ball == null)
            return;

        print($"Ballcount: {GameSystems.BallCount}");

        if (GameSystems.BallCount > 1)
        {
            Destroy(Ball.gameObject);
            GameSystems.ChangeBallCount(-1);
        }
        else { 
            GameSystems.ChangeLives(-1);
            Ball.BallSetup();
        }
    }
}
