using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //If the ball enters the "kill zone"
    {
        var ball = collision.GetComponent<Ball>();

        if (ball == null)
            return;

        GameSystems.ChangeLives(-1);
        ball.SetUpBall();
    }
}
