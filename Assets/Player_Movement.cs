using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // standard movement
    public float speed = 6;
    public float jumpPower = 14;

    float vx = 0;
    public static bool leftFlag = false;
    public static bool groundFlag = false;
    // dash
    public float dashVelocity = 30;
    public float dashCooldown = 3;
    
    float time;
    bool Can_dash = true;
    bool dashAction = false;
    float dashSpeed;

    // 폼 변환
    public static bool formConversion = false; //false는 검, true는 총.

    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        vx = 0;
        leftFlag = false;
        groundFlag = false;

        time = 0;
        Can_dash = true;
        dashAction = false;
    }

    void Update()
    {
        vx = 0;
        if (dashAction)
        {
            rbody.linearVelocity = new Vector2(dashSpeed, 0);
            dashSpeed *= 0.9f;
        }
        else
        {
            // standard movement
            if (Input.GetKey("d"))
            {
                vx = speed;
                leftFlag = false;
            }
            if (Input.GetKey("a"))
            {
                vx = -speed;
                leftFlag = true;
            }
            if (Input.GetKeyDown("space") && groundFlag)
            {
                Jump();
            }

            if (formConversion) // 총 쏘는 동안 느리게 이동
            {
                if (Input.GetMouseButton(0) && ShotBullet.BulletNumber > 0)
                {
                    rbody.linearVelocity = new Vector2(0.5f * vx, rbody.linearVelocity.y); 
                }
                else
                {
                    rbody.linearVelocity = new Vector2(vx, rbody.linearVelocity.y);   
                }
            }
            else
            {
                rbody.linearVelocity = new Vector2(vx, rbody.linearVelocity.y);
            }
            this.GetComponent<SpriteRenderer>().flipX = leftFlag;

            // dash
            if (leftFlag == false)
            {
                dashSpeed = dashVelocity;
            }
            else
            {
                dashSpeed = -dashVelocity;
            }
        }
        
        if (Can_dash)
        {
            if (Input.GetKeyDown("left shift"))
            {
                Can_dash = false;
                dashAction = true;
            }

            time = 0;
        }
        else
        {
            time += Time.deltaTime;

            if (time >= dashCooldown)
            {
                Can_dash = true;
            }
        }
        
        if (leftFlag == false)
        {
            if (dashSpeed < 10)
            {
                dashAction = false;
                dashSpeed = dashVelocity;
            }
        }
        else
        {
            if (dashSpeed > -10)
            {
                dashAction = false;
                dashSpeed = -dashVelocity;
            }
        }

        //form Conversion
        if (Input.GetKeyDown("r"))
        {
            formConversion = !formConversion;

            if (formConversion)
            {
                Debug.Log("모드 변환: 원거리 살상");
            }
            else
            {
                Debug.Log("모드 변환: 근접 살상");
            }
        }
    }

    void Jump()
    {
        rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, 0);
        rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            groundFlag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            groundFlag = false;
        }
    }
}
