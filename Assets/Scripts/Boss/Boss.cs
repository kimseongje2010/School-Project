using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss Instance{ get; private set; }

    public event Action<float> BossHit;
    public enum BossState
    {
        Idle,
        StartAttack,
        Telegraph,
        Attacking,
        Recovery,
        Dead,
        Init
    }
    public BossState bossState;
    public float hp;

    [SerializeField] private GameObject player;
    [SerializeField] private float maxHp = 5000;
    private BossInit bossInit;
    private List<IEnumerator> attacks;

    private void Awake()
    {
        Instance = this;
        hp = maxHp;
        bossInit = GetComponent<BossInit>();

        bossState = BossState.Init;

        attacks.Add(LaserAttack());
        attacks.Add(BulletAttack());
        attacks.Add(MissileAttack());
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (bossState == BossState.Idle)
        {
            DoAttack();
        }
    }

    private void DoAttack()
    {
        int idx = UnityEngine.Random.Range(0, attacks.Count - 1);

        StartCoroutine(attacks[idx]);
    }

    private IEnumerator LaserAttack()
    {
        bossState = BossState.StartAttack;
        Debug.Log("laser attack started!");
        yield return new WaitForSeconds(1f);

        bossState = BossState.Telegraph;
        Debug.Log("laser attack telegraph");

        yield return new WaitForSeconds(1f);

        bossState = BossState.Attacking;
        Debug.Log("laser attack activated");

        yield return new WaitForSeconds(1f);

        bossState = BossState.Recovery;
        Debug.Log("laser attack deactivated");

        yield return new WaitForSeconds(1f);

        bossState = BossState.Idle;
    }

    IEnumerator BulletAttack()
    {
        // Attack logic
        yield return new WaitForSeconds(2f);
    }

    IEnumerator MissileAttack()
    {
        // Attack logic
        yield return new WaitForSeconds(3f);
    }

    public void BeReady()
    {
        bossState = BossState.Idle;
    }

    public void GetDamaged(float damage)
    {
        hp -= damage;
        BossHit?.Invoke(hp);
    }

    public void TakeSlashDamage()
    {
        GetDamaged(50f);
    }

    public void TakeBulletDamage()
    {
        GetDamaged(5f);
    }
}
