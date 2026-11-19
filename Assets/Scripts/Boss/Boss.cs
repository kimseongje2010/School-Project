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
    [SerializeField] private Vector3 LAPos;
    [SerializeField] private float LADuration = 4f;

    private BossInit bossInit;
    private List<Func<IEnumerator>> attacks = new();
    private Vector3 initPos;
    private float t = 0;

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
        initPos = transform.position;
    }

    private void Update()
    {
        if (bossState == BossState.Idle)
        {
            DoAttack();
        }

        t += Time.deltaTime;
    }

    private void DoAttack()
    {
        int idx = UnityEngine.Random.Range(0, attacks.Count - 1);

        StartCoroutine(attacks[idx]());
    }

    private IEnumerator MoveTo(Vector3 targetPos, float time)
    {
        t = 0;
        Vector3 pos = transform.position;

        while (t <= time)
        {
            transform.position = Vector3.Lerp(pos, targetPos, t / time);
            yield return null;
        }

        yield return null;
    }

    private IEnumerator LaserAttack()
    {
        bossState = BossState.StartAttack;
        Debug.Log("laser attack started!");
        StartCoroutine(MoveTo(LAPos, 0.5f));
        yield return new WaitForSeconds(attackStartDelay);

        // Telegraph
        bossState = BossState.Telegraph;
        LA.origin = LAPos;
        LA.PrepareAttack(LADuration);
        Debug.Log("position set");
        yield return new WaitForSeconds(attackTelegraphDelay);

        // Attack
        bossState = BossState.Attacking;
        LA.StartAttack();
        yield return new WaitForSeconds(LADuration);

        // Recovery
        bossState = BossState.Recovery;
        LA.EndAttack();
        StartCoroutine(MoveTo(initPos, 0.5f));
        yield return new WaitForSeconds(attackRecoverDelay);

        bossState = BossState.Idle;
    }

    private IEnumerator BulletAttack()
    {
        // Attack logic
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator MissileAttack()
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
