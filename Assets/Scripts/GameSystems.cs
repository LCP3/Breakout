using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSystems : MonoBehaviour
{
    public static event Action<int> OnPlayerDeath;

    public static int Lives { get; set; }

    public static void ChangeLives(int lives)
    {
        Lives += lives;
        OnPlayerDeath?.Invoke(Lives); //UILives subscriber UpdateLivesText

        if (Lives == 0)
            SceneManager.LoadScene("Level1");
    }
}
