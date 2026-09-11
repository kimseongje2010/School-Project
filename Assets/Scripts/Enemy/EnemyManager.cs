using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum State
    {
        idle,
        attack
    }

    [SerializeField] private PointAtTarget pointAtTarget;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject follower;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float hp = 100f;
    [SerializeField] private float speed;
    [SerializeField] private float attackInterval = 4.0f;
    [SerializeField] private float bulletDamage = 5f;
    [SerializeField] private float slashDamage = 50f;
    [SerializeField] private bool isMovable;
    [SerializeField] private float attackRange = 10f;
    private EnemyAttack enemyAttack;
    private EnemyMovement enemyMovement;
    private float attackTimer = 0;
    public GameObject target;
    public bool lookAtTarget;
    public State state;

    void Awake()
    {
        if (isMovable)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            enemyMovement = GetComponent<EnemyMovement>();
        }
        enemyAttack = GetComponent<EnemyAttack>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.2f);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;

        if (Vector3.Distance(targetPos, transform.position) <= attackRange && pointAtTarget.isSeeingPlayer)
        {
            state = State.attack;
            pointAtTarget.drawLine = true;
        }
        else
        {
            state = State.idle;
            pointAtTarget.drawLine = false;
        }

        if (hp <= 0)
        {
            Die();
        }

        if (lookAtTarget)
        {
            follower.GetComponent<PointAtTarget>().PointAt(targetPos);
        }

        switch (state)
        {
            case State.attack:
                attackTimer += Time.deltaTime;

                if (attackTimer >= attackInterval)
                {
                    enemyAttack.AttackAt(targetPos);
                    attackTimer = 0f;
                }

                break;

            case State.idle:
                break;
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public void TakeBulletDamage()
    {
        hp -= bulletDamage;
    }

    public void TakeSlashDamage()
    {
        hp -= slashDamage;
    }

    public float GetHP()
    {
        return hp;
    }
}
