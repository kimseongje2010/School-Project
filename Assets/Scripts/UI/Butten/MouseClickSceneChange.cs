using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseClickSceneChange : MonoBehaviour
{
    public string nextscene = "";
    private SpriteRenderer sR;
    public static bool nextScene = false;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        sR.color = Color.white;
        nextScene = false;
    }

    void OnMouseUp()
    {
        nextScene = true;
    }

    void OnMouseOver()
    {
        sR.color = new Color(0.7f, 0.7f, 0.7f ,1f);
    }

    void OnMouseExit()
    {
        sR.color = Color.white;
    }
}
