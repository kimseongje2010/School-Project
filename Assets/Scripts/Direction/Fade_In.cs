using UnityEngine;

public class Fade_In : MonoBehaviour
{

    private SpriteRenderer sR;
    float transparency = 1f;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        sR.enabled = true;
        // FadeIn();
    }

    void FixedUpdate()
    {
        Vector3 pos = Camera.main.gameObject.transform.position;
        pos.z = -10;
        this.transform.position = pos;

        if (transparency > 0)
        {
            transparency -= 0.01f;
        }
        else
        {
            transparency = 0f;
        }
        sR.color = new Color (0f, 0f, 0f, transparency);
    }
    // public void FadeIn()
    // {
    //     transparency = 1f;
    //     while (transparency >= 0)
    //     {
    //         Debug.Log("Fade_In 실행");
    //         Debug.Log(transparency);
    //         Vector3 pos = Camera.main.gameObject.transform.position;
    //         pos.z = 0;
    //         this.transform.position = pos;

    //         sR.color = new Color (0f, 0f, 0f, transparency);

    //         if (transparency <= 0)
    //         {
    //             Debug.Log("Fade_In 종료");
    //             break;
    //         }
            
    //         transparency -= 0.01f;
            
    //     }
    // }
}
