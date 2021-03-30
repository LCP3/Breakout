using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void GameOver(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void GameOver(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
