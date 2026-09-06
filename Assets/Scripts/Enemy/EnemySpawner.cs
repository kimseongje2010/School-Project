using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject effect;
    [SerializeField] private float delay;
    float t = 0f;

    private void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        t += Time.deltaTime;

        if (t > delay)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
