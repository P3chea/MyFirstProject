using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Health healthComponent;
    public Text healthText;
    public Text scoreText;
    public Text finalScoreText;
    public GameObject scorePanel;
    public AudioSource coin;
    
    private int score = 0;

    private void Start()
    {
        scorePanel.gameObject.SetActive(false);
    }
    void Update()
    {
        if (healthComponent != null && healthText != null)
        {
            healthText.text = healthComponent.currentHealth.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            score ++;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
            coin.Play();
        }

        if(collision.CompareTag("Finish"))
        {
            scorePanel.gameObject.SetActive(true);
            finalScoreText.text = "Final Score:" + score.ToString();
        }
    }
}
