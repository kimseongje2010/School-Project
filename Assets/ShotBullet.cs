using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject newPrefab;
    Vector3 pos;
    public float shotingInterval = 0.15f;
    float S_time; // Shoting time
    float R_time; // Reloading time
    bool Can_shot;
    public static int BulletNumber = 30;
    public float ReloadTime;

    void Start()
    {
        S_time = 0;
        R_time = 0;
        Can_shot = true;
        BulletNumber = 30;
    }

    void Update()
    {
        if (Player_Movement.formConversion)
        {
            if (BulletNumber > 0)
            {
                if (Input.GetMouseButton(0) && Can_shot)
                {
                    Can_shot = false;
                    BulletNumber -= 1;
                    pos.y = this.transform.position.y + 0.25f;
                    pos.z = -0.1f;
                    if (Player_Movement.leftFlag)
                    {
                        pos.x = this.transform.position.x - 0.55f;
                    }
                    else
                    {
                        pos.x = this.transform.position.x + 0.55f;
                    }
                    GameObject newBullet = Instantiate(newPrefab) as GameObject;
                    newBullet.transform.position = pos;
                }
            }
        }
        
        if (Can_shot == false) // Shot 시간 계산
        {
            S_time += Time.deltaTime;
            if (S_time >= shotingInterval)
            {
                Can_shot = true;
                S_time = 0;
            }
        }
        if (BulletNumber <= 0) // Reload 시간 계산
        {
            R_time += Time.deltaTime;
            Debug.Log("Reloading");
            if (R_time >= ReloadTime)
            {
                BulletNumber = 30;
                R_time = 0;
            }
        }
    }
}
