using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class SpreadBullet : MonoBehaviour
{
    public Vector2 top = new(0, 1);
    public float spread = 120; // in degree
    public bool isCircle = true;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float interval = 0.1f;
    [SerializeField] private int count = 8;
    [SerializeField] private int cycles = 2;

    private void Start()
    {
        spread *= Mathf.Deg2Rad;
        if (isCircle)
        {
            spread = (count - 1) * Mathf.PI / (count / 2f);
        }
        StartCoroutine(SpawnBullets());
    }

    private void Cycle()
    {
        float topAngle = Mathf.Atan(top.y / top.x);
        float angle = topAngle;

        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(bullet, transform.position, quaternion.identity);
            EnemyBullet enemyBullet = tmp.GetComponent<EnemyBullet>();

            angle = topAngle - (spread / 2) + i * (spread / (count - 1));
            Vector3 direction = new(Mathf.Cos(angle), Mathf.Sin(angle));

            enemyBullet.SetSpeed(speed);
            enemyBullet.SetDirection(direction);
            angle += spread / count;
        }
    }

    private IEnumerator SpawnBullets()
    {
        for (int i = 0; i < cycles; i++)
        {
            Cycle();
            yield return new WaitForSeconds(interval);
        }

        Destroy(gameObject);
    }
}
