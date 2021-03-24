using UnityEngine;
using TMPro;

public class UILives : MonoBehaviour
{
    TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();

        GameSystems.Lives = 3; //Set up lives -- Want to refactor this and add to inspector
        UpdateLivesText(GameSystems.Lives); //Update UI
        GameSystems.OnPlayerDeath += UpdateLivesText; //Subscribing to and called by GameSystems on death
    }

    private void OnDestroy()
    {
        GameSystems.OnPlayerDeath -= UpdateLivesText; //Future proof unsub for menu/level change implementation
    }

    private void UpdateLivesText(int lives)
    {
        Debug.Log($"Lives updated to : {lives}");
        _text.SetText($"Lives: {lives}");
    }
}
