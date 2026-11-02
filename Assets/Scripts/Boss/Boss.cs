using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss Instance{ get; private set; }

    public enum BossState
    {
        Idle,
        Telegraph,
        Attacking,
        Recovery,
        Dead
    }
    public float hp;

    [SerializeField] private GameObject player;
    [SerializeField] private float maxHp = 5000;

    private void Awake()
    {
        Instance = this;
        hp = maxHp;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void GetDamaged(float damage)
    {
        hp -= damage;
    }
}
