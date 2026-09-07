using Unity.Mathematics;
using UnityEngine;

public class PointAtTarget : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;

    public void PointAt(Vector3 target)
    {
        Vector3 dirVector = target - transform.position;
        float angle = Mathf.Atan2(dirVector.y, dirVector.x);
        transform.rotation = quaternion.Euler(0, 0, angle);

        LayerMask mask = LayerMask.GetMask("Default");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVector.normalized, 100f, mask);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, hit.point);
        Debug.Log(hit.collider);
    }
}
