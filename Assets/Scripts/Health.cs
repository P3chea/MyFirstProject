using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float currentHealth;

    public Animator anim;

    private bool isAlive;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void Damages(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hit");
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth <= 0 && isAlive)
        {
            isAlive = false;
            anim.SetBool("IsDead", true);
        }
    }
    public void Kill()
    {
        isAlive = false;
        anim.SetBool("IsDead", true);
    }
}
