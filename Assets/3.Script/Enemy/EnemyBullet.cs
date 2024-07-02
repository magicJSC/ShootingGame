using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 총알 제어 코드
/// </summary>
public class EnemyBullet : MonoBehaviour, IBullet
{
    public int Damage { get; set; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPlayer>(out IPlayer player))
        {
            player.ApplyDamage(this);
            Destroy(gameObject);
        }
    }
}
