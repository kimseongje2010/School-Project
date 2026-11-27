using UnityEngine;

public class BossMissile : MonoBehaviour
{
    public float damage;

    private Rigidbody2D rb;
    private GameObject player;
    [SerializeField] private GameObject spriteObj;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float speed;
    private float t = 0;
    private Vector2 targetDir = new(1, 0);
    private Vector2 velDir = new(0, 1);
    private Vector2 moveDir = new(0, 0);

    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private GameObject explosionEffect;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
        if (t >= lifetime)
        {
            DestroySelf();
        }

        targetDir = (player.transform.position - transform.position).normalized;
        velDir = rb.linearVelocity.normalized;
        float dirDot = Vector2.Dot(velDir, targetDir);
        
        if (dirDot > 0)
        {
            moveDir = 2f * dirDot * targetDir - velDir; // 타겟 방향에 대해서 진행 방향의 반사 벡터
        }
        else
        {
            moveDir = -velDir; // 진행방향이 반대면 한번 더 뒤집기 = -진행방향
        }

        if (velDir.magnitude < 0.1)
        {
            moveDir = targetDir;
        }

        rb.AddForce(moveDir * speed, ForceMode2D.Force);

        float spriteAngle = Mathf.Atan(moveDir.y / moveDir.x) * Mathf.Rad2Deg;
        spriteObj.transform.rotation = Quaternion.Euler(0, 0, spriteAngle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Wall"))
        {
            // Debug.Log("collided with wall");
            DestroySelf();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealth.TakeDamage(damage);

            Explode();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)targetDir);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)velDir);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)moveDir);
    }

    public void DestroySelf()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    public void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
