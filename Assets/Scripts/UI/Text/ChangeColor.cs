using TMPro;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    float green = 1f;
    float blue = 1f;

    void Start()
    {
        tmpText.color = new Color(1f, green, blue, 1f);
    }
    void Update()
    {
        if (green > 0)
        {
            green -= 0.005f;
        } 
        else
        {
            green = 0;
        }

        if (blue > 0)
        {
            blue -= 0.005f;
        }
        else
        {
            blue = 0;
        }
        tmpText.color = new Color(1f, green, blue, 1f);
    }

}
