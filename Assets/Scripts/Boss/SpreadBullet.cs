using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class SpreadBullet : MonoBehaviour
{
    public Vector2 top = new(0, 1);
    public float spread = 120; // in degree
    public bool isCircle = true;
    public int cycles = 2;
    
    [SerializeField] private GameObject telegraphObj;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float interval = 0.1f;
    public int count = 8;

    private void Start()
    {
        
    }

    private void Cycle()
    {
        float topAngle = Mathf.Atan(top.y / top.x);

        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(bullet, transform.position, quaternion.identity);
            EnemyBullet enemyBullet = tmp.GetComponent<EnemyBullet>();

            float angle = topAngle - (spread / 2) + i * (spread / (count - 1));
            Vector3 direction = new(Mathf.Cos(angle), Mathf.Sin(angle));

            enemyBullet.SetSpeed(speed);
            enemyBullet.SetDirection(direction);
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

    private IEnumerator Telegraph(float t)
    {
        float topAngle = Mathf.Atan(top.y / top.x);

        for (int i = 0; i < count; i++)
        {
            float angle = topAngle - (spread / 2f) + i * (spread / (count - 1));
            Instantiate(telegraphObj, transform.position, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg));
        }

        yield return new WaitForSeconds(t);

        Attack();
    }

    public void Attack()
    {
        StartCoroutine(SpawnBullets());
    }

    public void StartAttack(float t)
    {
        spread *= Mathf.Deg2Rad;
        if (isCircle)
        {
            spread = (count - 1) * Mathf.PI / (count / 2f);
        }
        StartCoroutine(Telegraph(t));
    }
}
