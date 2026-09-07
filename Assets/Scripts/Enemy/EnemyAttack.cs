using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector3 instanceOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackAt(Vector3 pos)
    {
        Vector2 dir = (pos - (transform.position + instanceOffset)).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position + instanceOffset, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
        bullet.GetComponent<EnemyBullet>().SetDirection(dir);
    }
}
