using UnityEngine;

public class Center : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("CameraControl"))
        {
            Camera_Control.leftPosition = false;
            // Camera_Control.centerPosition = true;
            Camera_Control.rightPosition = false;
        }
    }

    void Update()
    {
        Vector3 pos = Camera.main.gameObject.transform.position;
        pos.z = 0;
        this.transform.position = pos;
    }
}
