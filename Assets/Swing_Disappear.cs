using UnityEngine;

public class Swing_Disappear : MonoBehaviour
{
    public float disappearTime = 0.2f;
    float time;
    bool right;
    bool didGaveDamage = false;

    public static Vector3 p_Position;

    void Start()
    {
        time = 0;

        if (!Player_Movement.leftFlag)
        {
            right = true;
        }
        else
        {
            right = false;
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= disappearTime)
        {
            Destroy(this.gameObject);
        }

        if (right)
        {
            Vector3 pos = p_Position;
            pos.x = p_Position.x + 1.4f;
            pos.y = p_Position.y + 0.4f;
            pos.z = -0.2f;
            this.transform.position = pos;
        }
        else
        {
            Vector3 pos = p_Position;
            pos.x = p_Position.x - 1.4f;
            pos.y = p_Position.y + 0.4f;
            pos.z = -0.2f;
            this.transform.position = pos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("triggered" + collision.gameObject);
        if (collision.gameObject.TryGetComponent<EnemyManager>(out EnemyManager component) && !didGaveDamage)
        {
            component.TakeSlashDamage();
            didGaveDamage = true;
            // Debug.Log("damaged");
        }
    }
}
