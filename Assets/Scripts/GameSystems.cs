using System;
using UnityEngine;

public class GameSystems : MonoBehaviour
{
    public static event Action<int> OnPlayerDeath;

    public static int Lives { get; set; }

    public static void ChangeLives(int lives)
    {
        Debug.Log($"In Change Lives, Lives = {Lives}");
        Lives += lives;
        Debug.Log($"Now lives = {Lives}");
        OnPlayerDeath?.Invoke(Lives);
    }

}
