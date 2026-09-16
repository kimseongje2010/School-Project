using UnityEngine;

public class DroneExplosion : MonoBehaviour
{
    public GameObject newPrefab;
    int hp = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pos = this.transform.position;
            pos.z = -0.3f;
            GameObject ExplosionEffect = Instantiate(newPrefab) as GameObject;
            ExplosionEffect.transform.position = pos;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            hp -= 1;
        }
        else if (other.CompareTag("Swing"))
        {
            hp -= 2;
        }
    }

    void Update()
    {
        if (hp <= 0 )
        {
            Vector3 pos = this.transform.position;
            pos.z = -0.3f;
            GameObject ExplosionEffect = Instantiate(newPrefab) as GameObject;
            ExplosionEffect.transform.position = pos;
            Destroy(this.gameObject);
        }
    }
}
