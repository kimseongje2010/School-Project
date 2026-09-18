using UnityEngine;

public class Camera_Control : MonoBehaviour
{   
    Vector3 base_pos;
    public static bool leftPosition;
    public static bool rightPosition;
    // public static bool topPosition;
    // public static bool bottomPosition;

    void Start()
    {
        base_pos = Camera.main.gameObject.transform.position;
        leftPosition = false;
        rightPosition = false;
        // topPosition = false;
        // bottomPosition = false;
    }

    void LateUpdate()
    {
        Vector3 pos = this.transform.position;
        pos.z = -10;
        pos.y = Camera.main.gameObject.transform.position.y;
        if (leftPosition)
        {
            pos.x = this.transform.position.x + 1.5f;
            Camera.main.gameObject.transform.position = pos;

        }
        else if (rightPosition)
        {
            pos.x = this.transform.position.x - 1.5f;
            Camera.main.gameObject.transform.position = pos;
        }

        // Debug.Log(pos);

        // if (topPosition)
        // {
        //     pos.y = this.transform.position.y - 2.5f;
        //     Camera.main.gameObject.transform.position = pos;
        // }
        // else if (bottomPosition)
        // {
        //     pos.y = this.transform.position.y + 2.5f;
        //     Camera.main.gameObject.transform.position = pos;
        // }
    }
}
