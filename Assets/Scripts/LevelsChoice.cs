using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public int SceneNumber;
    public void Level()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNumber);
    }
}