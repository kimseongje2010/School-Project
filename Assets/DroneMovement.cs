using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public string playerName = "";
    bool findPlayer = false;
    public float speed;
    int posCount = 10;
    int count = 0;
    Rigidbody2D rbody;
    Vector3 follow_pos;
    GameObject player;
    
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        player = GameObject.Find(playerName);
    }

    void Update()
    {
        Vector3 p_Pos = player.transform.position;
        Vector3 pos = this.transform.position;

        if (((pos.x - p_Pos.x) <= 6 || pos.x <= p_Pos.x) && !findPlayer)
        {
            follow_pos = player.transform.position;
            findPlayer = true;
            
        }
    }

    void FixedUpdate()
    {
        if (findPlayer)
        {
            Vector3 dir = (follow_pos - this.transform.position).normalized;
            float vx = dir.x * speed;
            float vy = dir.y * speed;
            rbody.linearVelocity = new Vector2(vx, vy);
            this.GetComponent<SpriteRenderer>().flipX = (vx <0);

            if (count >= posCount)
            {
                follow_pos = player.transform.position;
                count = 0;
            }
            else
            {
                count += 1;
            }
        }
    }
}
