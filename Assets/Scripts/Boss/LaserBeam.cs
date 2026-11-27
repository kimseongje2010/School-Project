using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public Vector3 dir;

    [SerializeField] private float damage;
    private LineRenderer lr;
    private bool didHitPlayer = false;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir);
        if (hit)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);

            if (!didHitPlayer && hit.collider.gameObject.TryGetComponent(out PlayerHealth component))
            {
                Debug.Log("laser beam hit player!");
                component.TakeDamage(damage);
                didHitPlayer = true;
            }
        }
    }
}
