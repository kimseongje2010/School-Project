using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject follower;
    [SerializeField] private float hp = 100;
    [SerializeField] private float speed;
    private float attackTimer;
    public GameObject target;
    public bool followTarget;

    void Awake()
    {
        // rb = GetComponent<Rigidbody2D>();
        // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
