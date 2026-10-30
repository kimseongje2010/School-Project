using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss Instance{ get; private set; }

    public float hp;


    [SerializeField] private GameObject defaultBulletObj;
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
}
