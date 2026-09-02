using Unity.Mathematics;
using UnityEngine;

public class PointAtTarget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointAt(Vector3 target)
    {
        Vector3 dirVector = transform.position - target;
        float angle = Mathf.Atan2(dirVector.y, dirVector.x);
        transform.rotation = quaternion.Euler(0, 0, angle);
    }
}
