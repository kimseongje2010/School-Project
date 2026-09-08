using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hp = 100f;
    public float damageMultiplier = 1f;
    public bool canBeDamaged = true;

    [SerializeField] private PlayerDead playerDead;
    [SerializeField] private float bulletDamage = 4f;

    public void TakeBulletDamage(float mult = 1)
    {
        TakeDamage(bulletDamage);
    }

    public void TakeDamage(float damage)
    {
        if (canBeDamaged)
        {
            hp -= damage * damageMultiplier;

            if (hp <= 0)
            {
                playerDead.PlayerDie();
            }
        }
    }
}
