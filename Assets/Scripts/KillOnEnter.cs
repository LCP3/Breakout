using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //If the ball enters the "kill zone"
    {
        var ball = collision.GetComponent<Ball>(); //Cache

        if (ball != null) // Make sure the only possibility is the ball
            SceneManager.LoadScene("Level1"); // Kill the player, reload level as temporary game over
    }
}
