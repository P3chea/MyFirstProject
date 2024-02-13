using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public Health player;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        if (player.currentHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameOverPanel.SetActive(false);
            Time.timeScale = 1f;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameOver"))
        {
            player.currentHealth = 0;
        }
    }
}
