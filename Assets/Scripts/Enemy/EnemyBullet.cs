using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float aliveTimer = 16f;
    private Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
        aliveTimer -= Time.deltaTime;
        if (aliveTimer <= 0)
        {
            DestroySelf();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("collided");
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Wall"))
        {
            // Debug.Log("collided with wall");
            DestroySelf();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            // Debug.Log("collided with player");
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
}
