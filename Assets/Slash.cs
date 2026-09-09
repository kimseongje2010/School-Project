using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject newPrefab;

    float slashVelocity = 20;
    public float slashCooldown = 0.5f;
    public float slashDashCooldown = 1f;

    float S_time; // Slash time
    float SD_time; // SlashDash time
    bool Can_slash = true;
    bool Can_slashdash = true;
    public static bool slashAction = false;
    float slashSpeed;

    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        S_time = 0;
        SD_time = 0;
        Can_slash = true;
        Can_slashdash = true;
        slashAction = false;
        slashSpeed = slashVelocity;
    }

    void Update()
    {
        Swing_Disappear.p_Position = this.transform.position;
        
        if (Player_Movement.formConversion == false)
        {
            if (Can_slash && Can_slashdash && !Player_Movement.dashAction)
            {
                if ((Input.GetKey("a") || Input.GetKey("d")) && Input.GetMouseButton(0)) // slash 키 입력 감지
                {
                    Can_slashdash = false;
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
                else if (Input.GetMouseButton(0))
                {
                    Can_slash = false;
                    if (Player_Movement.leftFlag == false)
                    {
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
                SD_time = 0;
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
        if (!Can_slashdash) // slash 시간 계산
        {
            SD_time += Time.deltaTime;

            if (SD_time >= slashDashCooldown)
            {
                Can_slashdash = true;
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
                if (slashSpeed < 10)
                {
                    slashAction = false;
                    slashSpeed = slashVelocity;
                }
            }
            else
            {
                if (slashSpeed > -10)
                {
                    slashAction = false;
                    slashSpeed = -slashVelocity;
                }
            }
        }
    }
}