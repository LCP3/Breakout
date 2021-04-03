using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        GameSystems.OnScoreChange += UpdateScoreText;
        UpdateScoreText(GameSystems.Score);
    }

    private void OnDestroy()
    {
        GameSystems.OnScoreChange -= UpdateScoreText;
    }

    public void UpdateScoreText(int score)
    {
        _text.SetText($"Score: {score}");
    }
}
