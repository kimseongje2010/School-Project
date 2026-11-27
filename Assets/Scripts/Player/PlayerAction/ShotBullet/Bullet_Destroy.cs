using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet_Destroy : MonoBehaviour
{
    [SerializeField] private Vector2 normalRange = new(9f, 5.2f);
    [SerializeField] private Vector2 bossRoomRange = new(20f, 12f);
    private GameObject camObj;
    private bool isInBossRoom = false;

    void Start()
    {
        camObj = Camera.main.gameObject;
        isInBossRoom = SceneManager.GetActiveScene().name == "BossRoom";
    }

    void Update()
    {
        float xDist = Mathf.Abs(transform.position.x - camObj.transform.position.x);
        float yDist = Mathf.Abs(transform.position.y - camObj.transform.position.y);

        if (
            isInBossRoom && (yDist >= bossRoomRange.x || yDist >= bossRoomRange.y) ||
            !isInBossRoom && (xDist >= normalRange.x || yDist >= normalRange.y)
            )
        {
            Destroy(this.gameObject);
            Debug.Log("too far");
        }

        // if (this.transform.position.x >= Camera.main.gameObject.transform.position.x + 9f
        // || this.transform.position.x <= Camera.main.gameObject.transform.position.x - 9f
        // || this.transform.position.y >= Camera.main.gameObject.transform.position.y + 5.2f
        // || this.transform.position.y <= Camera.main.gameObject.transform.position.y -5.2f)
        // {
        //     Destroy(this.gameObject);
        //     Debug.Log("too far");
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("Wall") || other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (other.TryGetComponent<EnemyManager>(out EnemyManager component))
        {
            component.TakeBulletDamage();
            Destroy(gameObject);
        }
        if (other.TryGetComponent<Boss>(out Boss component1))
        {
            component1.TakeBulletDamage();
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent(out BossMissile component2))
        {
            component2.DestroySelf();
        }
    }
}
