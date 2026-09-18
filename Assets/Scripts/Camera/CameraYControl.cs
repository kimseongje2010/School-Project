using Unity.VisualScripting;
using UnityEngine;

public class CameraYControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float upThreshold;
    [SerializeField] private float downThreshold;
    [SerializeField] private float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float playerPosY = player.transform.position.y;
        float cameraPosY = transform.position.y;

        if (playerPosY >= cameraPosY + upThreshold)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
        
        if (playerPosY <= cameraPosY - downThreshold)
        {
            transform.position -= speed * Time.deltaTime * Vector3.up;
        }
    }
}
