using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject newPrefab;

    public float slashVelocity = 10;
    public float slashCooldown = 0.5f;

    float S_time; // Slash time
    bool Can_slash = true;
    public static bool slashAction = false;
    float slashSpeed;

    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        S_time = 0;
        Can_slash = true;
        slashAction = false;
        slashSpeed = slashVelocity;
    }

    void Update()
    {
        Swing_Disappear.p_Position = this.transform.position;
        
        if (Player_Movement.formConversion == false)
        {
            if (Can_slash && !Player_Movement.dashAction)
            {
                if (Input.GetMouseButton(0)) // slash 키 입력 감지
                {
                    Can_slash = false;
                    slashAction = true;
                    if (Player_Movement.leftFlag == false)
                    {
                        slashSpeed = slashVelocity;

                        Vector3 pos = this.transform.position;
                        pos.x = this.transform.position.x + 1.4f;
                        pos.y = this.transform.position.y + 0.4f;
                        pos.z = -0.2f;
                        GameObject newSwing = Instantiate(newPrefab) as GameObject;
                        newSwing.transform.position = pos;
                        newSwing.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        slashSpeed = -slashVelocity;

                        Vector3 pos = this.transform.position;
                        pos.x = this.transform.position.x - 1.4f;
                        pos.y = this.transform.position.y + 0.4f;
                        pos.z = -0.2f;
                        GameObject newSwing = Instantiate(newPrefab) as GameObject;
                        newSwing.transform.position = pos;
                        newSwing.GetComponent<SpriteRenderer>().flipX = true;
                    }
                }

                S_time = 0;
            }
        }

        if (!Can_slash) // slash 시간 계산
        {
            S_time += Time.deltaTime;

            if (S_time >= slashCooldown)
            {
                Can_slash = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (slashAction && !Player_Movement.dashAction)
        {
            rbody.linearVelocity = new Vector2(slashSpeed, 0);
            slashSpeed *= 0.9f;
            // Debug.Log("slash");

            if (Player_Movement.leftFlag == false)
            {
                if (slashSpeed < 5)
                {
                    slashAction = false;
                    slashSpeed = slashVelocity;
                }
            }
            else
            {
                if (slashSpeed > -5)
                {
                    slashAction = false;
                    slashSpeed = -slashVelocity;
                }
            }
        }
    }
}