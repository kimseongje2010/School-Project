using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{

    public string nextscene = "";
    public static bool isDead = false;

    void Start()
    {
        Time.timeScale = 1;
        isDead = false;
    }

    void Update()
    {
        if (this.transform.position.y < -7)
        {
            PlayerDie();
        }

        // if (isDead)    
        // {
        //     Debug.Log("플레이어가 죽었습니다");
        // }S
    }
    
    public void PlayerDie()
    {
        isDead = true;
        SceneManager.LoadScene("DeadScene");
    }
}
