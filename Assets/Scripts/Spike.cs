using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
    private Health healthScript;
    private bool isDamaging = false;

    private void Start()
    {
        healthScript = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isDamaging)
            {
                StartCoroutine(ApplyDamageOverTime());
            }
        }
    }

    private IEnumerator ApplyDamageOverTime()
    {
        isDamaging = true;

        while (healthScript.currentHealth > 0)
        {
            healthScript.Damages(2);
            healthScript.anim.SetTrigger("Hit");

            if (healthScript.currentHealth <= 0)
            {
                healthScript.Kill();
                yield break;
            }

            yield return new WaitForSeconds(2f);
        }
    }
}
