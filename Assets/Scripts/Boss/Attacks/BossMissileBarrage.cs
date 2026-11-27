using System.Collections;
using UnityEngine;

public class BossMissileBarrage : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float initForce = 1f;
    [SerializeField] private float distance = 1f;
    [SerializeField] private float interval = 0.3f;
    [SerializeField] private int count = 5;
    [SerializeField] private int cycles = 3;

    private IEnumerator Cycle()
    {
        for (int i = 1; i < count + 1; i++)
        {
            float angle = (Mathf.PI * i / (count + 1)) + (Mathf.PI / 2f);
            Vector2 dirR = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 dirL = new Vector2(-Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            
            GameObject tmpR = Instantiate(missilePrefab, pos + dirR * distance, Quaternion.identity);
            Rigidbody2D componentR = tmpR.GetComponent<Rigidbody2D>();
            componentR.AddForce(dirR * initForce, ForceMode2D.Impulse);

            GameObject tmpL = Instantiate(missilePrefab, pos + dirL * distance, Quaternion.identity);
            Rigidbody2D componentL = tmpL.GetComponent<Rigidbody2D>();
            componentL.AddForce(dirL * initForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(interval);
        }

        yield return null;
    }

    private IEnumerator Attack()
    {
        for (int i = 0; i < cycles; i++)
        {
            StartCoroutine(Cycle());

            yield return new WaitForSeconds(0.5f);
        }

        yield return null;
    }

    public void StartAttack()
    {
        StartCoroutine(Attack());
    }
}
