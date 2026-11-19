using Unity.Mathematics;
using UnityEngine;

public class BossLaserAttack : MonoBehaviour
{
    public Vector2 origin = Vector3.zero;
    private LineRenderer lr;
    private float damage = 5;
    private float dur;
    private float t = 0;
    private bool startedAttack = false;
    private bool didHitPlayer = false;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (startedAttack && t <= dur)
        {
            float x = Mathf.SmoothStep(0, 1, t / dur);
            float pi = Mathf.PI;

            Vector2 targetDir = new(Mathf.Cos(pi*x-pi), Mathf.Sin(pi*x-pi));
            
            RaycastHit2D hit = Physics2D.Raycast(origin, targetDir);
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.CompareTag("Player") && !didHitPlayer)
            {
                Debug.Log("Hit Player!");
                didHitPlayer = true;
                PlayerHealth component = hitObj.GetComponent<PlayerHealth>();
                component.TakeDamage(damage);
            }

            lr.SetPosition(1, hit.point);

            t += Time.deltaTime;
        }
        
        // Debug.Log(t);
    }

    public void PrepareAttack(float duration)
    {
        dur = duration;
        lr.SetPosition(0, origin);
        lr.SetPosition(1, new Vector3(-13, origin.y, 0));
    }

    public void StartAttack()
    {
        startedAttack = true;
    }
    
    public void EndAttack()
    {
        startedAttack = false;
        didHitPlayer = false;

        lr.SetPosition(1, origin);

        t = 0;
    }
}
