using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject follower;
    [SerializeField] private float hp = 100f;
    [SerializeField] private float speed;
    [SerializeField] private float attackInterval = 4.0f;
    private EnemyAttack enemyAttack;
    private float attackTimer = 0;
    public GameObject target;
    public bool followTarget;

    void Awake()
    {
        // rb = GetComponent<Rigidbody2D>();
        // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemyAttack = GetComponent<EnemyAttack>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        
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

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public float GetHP()
    {
        return hp;
    }
}
