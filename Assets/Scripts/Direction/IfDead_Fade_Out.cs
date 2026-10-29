using UnityEngine;
using UnityEngine.SceneManagement;

public class IfDead_Fade_Out : MonoBehaviour
{
    private SpriteRenderer sR;
    float transparency = 0f;
    // int frame;
    // int waitFrame = 50;
    public string nextscene;

    void Start()
    {
        // frame = 0;
        sR = GetComponent<SpriteRenderer>();
        transparency = 0f;
        sR.color = new Color (0f, 0f, 0f, transparency);
        sR.enabled = true;
    }

    void FixedUpdate()
    {
        Vector3 pos = Camera.main.gameObject.transform.position;
        pos.z = 0;
        this.transform.position = pos;
        if (PlayerDead.isDead)
        {
            // Debug.Log("플레이어가 죽었습니다.");
            if (transparency < 1)
            {
                transparency += 0.05f;
            }
            else
            {
                transparency = 1f;
                SceneManager.LoadScene(nextscene);
            }
            sR.color = new Color (0f, 0f, 0f, transparency);
        }

        // if (transparency >= 1)
        // {
        //     frame += 1;

        //     if (frame >= waitFrame)
        //     {
        //         SceneManager.LoadScene(nextscene);
        //     }
        // }
    }
}
