using UnityEngine;

public class BossMissile : MonoBehaviour
{
    public float damage;

    private Rigidbody2D rb;
    private GameObject player;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float speed;
    private float t = 0;

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
    void Update()
    {
        t += Time.deltaTime;
        if (t >= lifetime)
        {
            DestroySelf();
        }

        Vector3 vel = player.transform.position - transform.position;
        vel.z = 0;
        vel.Normalize();

        rb.AddForce(vel * speed);
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
}
