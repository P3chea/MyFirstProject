using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public int SceneNumber;
    public void Level()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNumber);
    }
}

