using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject follower;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float hp = 100f;
    [SerializeField] private float speed;
    [SerializeField] private float attackInterval = 4.0f;
    [SerializeField] private float bulletDamage = 5f;
    [SerializeField] private float slashDamage = 50f;
    [SerializeField] private bool isMovable;
    private EnemyAttack enemyAttack;
    private EnemyMovement enemyMovement;
    private Rigidbody2D rb;
    private float attackTimer = 0;
    public GameObject target;
    public bool followTarget;

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

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        
        if (hp <= 0)
        {
            Die();
        }

        if (followTarget)
        {
            follower.GetComponent<PointAtTarget>().PointAt(targetPos);
        }

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            enemyAttack.AttackAt(targetPos);
            attackTimer = 0f;
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
