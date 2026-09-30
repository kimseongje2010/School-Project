using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.value = playerHealth.hp / playerHealth.maxHp;
    }
}
