using UnityEngine;

public class BossFloat : MonoBehaviour
{
    [SerializeField] GameObject SpriteObj;
    [SerializeField] private float fps = 12f;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private float amplitude = 1f;
    private float t = 0;
    private float timer = 0;

    private void Update()
    {
        t += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= 1f / fps)
        {
            UpdatePosition();
            timer = 0;
        }
    }

    private void UpdatePosition()
    {
        SpriteObj.transform.position = new Vector3(
            transform.position.x, 
            transform.position.y + (Mathf.Sin(Mathf.PI * frequency * t) * amplitude),
            transform.position.z
            );
    }
}
