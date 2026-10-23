using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseClickSceneChange : MonoBehaviour
{
    public string nextscene = "";
    private SpriteRenderer sR;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        sR.color = Color.white;
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene(nextscene);
    }

    void OnMouseOver()
    {
        sR.color = new Color(0.75f, 0.75f, 0.75f ,1f);
    }

    void OnMouseExit()
    {
        sR.color = Color.white;
    }
}
