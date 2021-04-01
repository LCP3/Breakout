using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //If the ball enters the "kill zone"
    {
        var Ball = collision.GetComponent<Ball>();

        if (Ball == null)
            return;

        GameSystems.ChangeLives(-1);
        Ball.BallSetup();
    }
}
