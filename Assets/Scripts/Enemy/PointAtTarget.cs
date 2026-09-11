using Unity.Mathematics;
using UnityEngine;

public class PointAtTarget : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    public bool isSeeingPlayer;
    public bool drawLine;

    public void PointAt(Vector3 target)
    {
        Vector3 dirVector = target - transform.position;
        float angle = Mathf.Atan2(dirVector.y, dirVector.x);
        transform.rotation = quaternion.Euler(0, 0, angle);

        LayerMask mask = LayerMask.GetMask("Default");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVector.normalized, 100f, mask);

        lr.enabled = drawLine;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, hit.point);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            isSeeingPlayer = true;
        }
        else
        {
            isSeeingPlayer = false;
        }
        // Debug.Log(hit.collider);
    }
}
