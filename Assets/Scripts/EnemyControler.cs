using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private float speed, TimeToRevert;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform[] stopPoints;

    private Rigidbody2D enemyRB;
    private float attackDamage = 3;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;
    private const float ATTACK_STATE = 3;

    private float currentState, currentTimeToRevert;

    void Start()
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }

        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                enemyRB.velocity = Vector2.right * speed;
                break;
            case REVERT_STATE:
                spriteRenderer.flipX = !spriteRenderer.flipX;
                speed *= -1;
                currentState = WALK_STATE;
                break;
            case ATTACK_STATE:
                enemyRB.velocity = Vector2.zero;
                break;

        }

        animator.SetFloat("Walk", Mathf.Abs(enemyRB.velocity.x));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stop"))
            currentState = IDLE_STATE;

        if (collision.CompareTag("Player"))
        {
            currentState = ATTACK_STATE;
            animator.SetTrigger("Attack");

            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Damages(attackDamage);
            }
        }
    }
}