using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHp = 5000;


    private void Awake()
    {
        hp = maxHp;
    }
}
