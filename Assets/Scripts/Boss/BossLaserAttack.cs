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

            Vector2 targetDir = new(Mathf.Cos((2 * math.PI * x) + (Mathf.PI / 2)), Mathf.Sin((2 * math.PI * x) + (Mathf.PI / 2)));
            
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
        lr.SetPosition(1, new Vector3(0, 7, 0));
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
