using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Categorization;

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
    [SerializeField] private float attackStartDelay = 1f;
    [SerializeField] private float attackTelegraphDelay = 1f;
    [SerializeField] private float attackRecoverDelay = 1f;

    [Header ("Laser Attack")]
    private BossLaserAttack LA;
    [SerializeField] private float LADuration = 4f;

    private BossInit bossInit;
    private List<Func<IEnumerator>> attacks = new();
    // private float t = 0;

    private void Awake()
    {
        Instance = this;
        hp = maxHp;
        bossInit = GetComponent<BossInit>();
        LA = GetComponent<BossLaserAttack>();

        bossState = BossState.Init;

        attacks.Add(LaserAttack);
        // attacks.Add(BulletAttack());
        // attacks.Add(MissileAttack());
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

        StartCoroutine(attacks[idx]());
    }

    private IEnumerator LaserAttack()
    {
        bossState = BossState.StartAttack;
        Debug.Log("laser attack started!");
        yield return new WaitForSeconds(attackStartDelay);

        // Telegraph
        bossState = BossState.Telegraph;
        LA.PrepareAttack(LADuration);
        yield return new WaitForSeconds(attackTelegraphDelay);

        // Attack
        bossState = BossState.Attacking;
        LA.StartAttack();
        yield return new WaitForSeconds(LADuration);

        // Recovery
        bossState = BossState.Recovery;
        LA.EndAttack();
        yield return new WaitForSeconds(attackRecoverDelay);

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
