using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (this.transform.position.y < -7)
        {
            Time.timeScale = 0;
        }
    }
}
