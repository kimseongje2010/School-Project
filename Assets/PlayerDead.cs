using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{

    public string nextscene = "";

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
        SceneManager.LoadScene(nextscene);
    }
}
