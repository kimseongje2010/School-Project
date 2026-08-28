using UnityEngine;

public class Right : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("CameraControl"))
        {
            Camera_Control.leftPosition = false;
            // Camera_Control.centerPosition = false;
            Camera_Control.rightPosition = true;
        }
    }

    void Update()
    {
        Vector3 pos = Camera.main.gameObject.transform.position;
        pos.x = Camera.main.gameObject.transform.position.x + 6f;
        pos.z = 0;
        this.transform.position = pos;
    }
}
