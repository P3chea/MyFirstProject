using UnityEngine;

public class Enemy : MonoBehaviour
    {
        public int maxHp;
        public int currentHp;

        public Animator enemyAnimator;
        public AudioSource attack;

        private Health player;
        private float timeBtwAttack;
        private float startTimeBtwAttack = 1f;
        private float lastAttackTime;

        void Start()
        {
            currentHp = maxHp;
            enemyAnimator = GetComponent<Animator>();
            player = GetComponent<Health>();
        }

        private void Update()
        {
            timeBtwAttack -= Time.deltaTime;
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;
            timeBtwAttack = startTimeBtwAttack;

            enemyAnimator.SetTrigger("Hit");

            if (currentHp <= 0)
            {
                Die();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                player = collision.gameObject.GetComponent<Health>();
                if (player != null)
                {
                    if (timeBtwAttack <= 0)
                    {
                        enemyAnimator.SetTrigger("Attack");
                        attack.Play();
                        lastAttackTime = Time.time;
                        timeBtwAttack = startTimeBtwAttack;
                    }
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && timeBtwAttack <= 0)
            {
                enemyAnimator.SetTrigger("Attack");
                lastAttackTime = Time.time;
                timeBtwAttack = startTimeBtwAttack;
            }
        }

        public void OnEnemyAttack()
        {
            if (player != null)
            {
                player.Damages(Random.Range(0, 4));
            }
        }

        void Die()
        {
            enemyAnimator.SetBool("Dead", true);

            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }

