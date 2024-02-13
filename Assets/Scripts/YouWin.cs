using UnityEngine;

public class YouWin : MonoBehaviour
{
    public GameObject youWin;
    public ParticleSystem part;

    void Start()
    {
        youWin.SetActive(false);
        part.gameObject.SetActive(false);
        part.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndGame"))
        {
            part.gameObject.SetActive(true);
            part.Play();
            Invoke("Congratulations", 2f);
        }
    }

    void Congratulations()
    {
        youWin.SetActive(true);
        Time.timeScale = 0;
    }
}
