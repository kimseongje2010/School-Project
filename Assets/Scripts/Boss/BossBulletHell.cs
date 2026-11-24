using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class SpawnData
{
    public Vector3 position;
    public Vector2 top;
    public bool isCircle;
    public float spread;
    public float duration;
    public int count;
}

public class BossBulletHell : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private SpawnData[] pattern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Attack(float t)
    {
        int l = pattern.Length;

        for (int i = 0; i < l; i++)
        {
            GameObject tmp = Instantiate(prefab, pattern[i].position, Quaternion.identity);
            SpreadBullet component = tmp.GetComponent<SpreadBullet>();

            component.top = pattern[i].top;
            component.spread = pattern[i].spread;
            component.isCircle = pattern[i].isCircle;
            component.count = pattern[i].count;
            component.StartAttack(t); 

            if (pattern[i].duration != 0)
            {
                yield return new WaitForSeconds(pattern[i].duration);
            }
        }

        yield return null;
    }

    public void PrepareAttack()
    {
        
    }

    public void StartAttack(float t)
    {
        StartCoroutine(Attack(t));
    }
    
    public void EndAttack()
    {
        
    }
}
