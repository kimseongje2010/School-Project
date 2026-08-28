using UnityEngine;

public class Bullet_move : MonoBehaviour
{
    bool moveLeft;
    public float bulletSpeed = 40;
    Rigidbody2D rbody;
    Vector3 rot;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        if (Player_Movement.leftFlag)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (moveLeft)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0); // rotation에는 Vector 사용 불가! Quaternion 사용 가능!
            rbody.linearVelocity = new Vector2(-bulletSpeed, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            rbody.linearVelocity = new Vector2(bulletSpeed, 0);
        }
    }

    void Update()
    {
        
    }
}
