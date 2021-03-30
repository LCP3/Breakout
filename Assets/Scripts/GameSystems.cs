using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSystems : MonoBehaviour
{
    public static event Action<int> OnPlayerDeath;
    public static event Action<int> OnScoreChange;

    public static int Lives { get; set; }
    public static int Score { get; private set; }

    private void Start()
    {
        Score = 0; //Score setup
    }

    public static void ChangeLives(int lives)
    {
        Lives += lives;
        OnPlayerDeath?.Invoke(Lives); //UILives subscriber UpdateLivesText

        if (Lives == 0)
            SceneManager.LoadScene("GameOver");
    }

    public static void AddScore(int points)
    {
        Score += points;
        OnScoreChange?.Invoke(Score);
    }
}
