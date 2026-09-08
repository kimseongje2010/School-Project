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
            PlayerDie();
        }
    }
    
    public void PlayerDie()
    {
        Time.timeScale = 0;
    }
}
