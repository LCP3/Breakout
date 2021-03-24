using UnityEngine;
using TMPro;
using System;

public class UILives : MonoBehaviour
{
    TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();

        GameSystems.Lives = 3;
        UpdateLivesText(GameSystems.Lives);
        GameSystems.OnPlayerDeath += UpdateLivesText;
    }

    private void UpdateLivesText(int lives)
    {
        Debug.Log($"Lives updated to : {lives}");
        _text.SetText($"Lives: {lives}");
    }
}
