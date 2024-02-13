using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator attack;

    public Transform attackPoint;
    public LayerMask enemy;
    public AudioSource swordAttack;

    public float attackRange = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    private void Attack()
    {
        attack.SetTrigger("Attack");
        swordAttack.Play();

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemy);

        foreach (Collider2D collider in hitEnemy)
        {
            collider.GetComponent<Enemy>().TakeDamage(Random.Range(0, 5));
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
