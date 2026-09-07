using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float duration;
    private float t = 0;

    void Update()
    {
        t += Time.deltaTime;

        if (t >= duration)
        {
            Destroy(gameObject);
        }
    }
}
