using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public ParticleSystem finish;
    public Button nextLevelButton;

    void Start()
    {
        finish.gameObject.SetActive(false);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0f;
            finish.Play();
            finish.gameObject.SetActive(true);
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
