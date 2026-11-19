using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class BossFloat : MonoBehaviour
{
    [SerializeField] GameObject SpriteObj;
    [SerializeField] GameObject DamageEffect;
    [SerializeField] private float fps = 12f;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private float amplitude = 1f;
    private float t = 0;
    private float timer = 0;
    private float stopper = 1f;

    private void Start()
    {
        Boss.Instance.BossHit += BossHitEventHandler;
    }

    private void Update()
    {
        t += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= 1f / fps)
        {
            UpdatePosition();
            timer = 0;
        }
    }

    private IEnumerator LerpStopper(float end)
    {
        float start = stopper;
        float fac = 0;

        while (fac <= 1f)
        {
            stopper = Mathf.Lerp(start, end, fac);
            fac += Time.deltaTime;
            yield return null;
        }

        stopper = end;
    }

    private void UpdatePosition()
    {
        SpriteObj.transform.position = new Vector3(
            transform.position.x, 
            transform.position.y + (Mathf.Sin(Mathf.PI * frequency * t) * amplitude * stopper),
            transform.position.z
            );
    }

    private void BossHitEventHandler(float damage)
    {
        Instantiate(DamageEffect, SpriteObj.transform);
    }

    public void SetMovementActive(bool active = true)
    {
        if (active)
        {
            StartCoroutine(LerpStopper(1f));
        }
        else
        {
            StartCoroutine(LerpStopper(0f));
        }
    }
}
