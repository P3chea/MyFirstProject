using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPanelActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPanelActive)
            {
                PauseGame();
            }
            else if (isPanelActive)
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        isPanelActive = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        isPanelActive = false;
    }

    public void ResetGame()
    {
        Time.timeScale = 1.0f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
