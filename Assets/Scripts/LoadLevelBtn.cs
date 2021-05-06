using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelBtn : MonoBehaviour
{
    public void GameOver(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        GameSystems.ChangeLives(3);
    }
}
