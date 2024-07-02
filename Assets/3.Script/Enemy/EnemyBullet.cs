using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 총알 제어 코드
/// </summary>
public class EnemyBullet : MonoBehaviour, ICollisionDamage
{
    public int CollisionDamage { get; set; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPlayer>(out var player))
        {
            player.ApplyDamage(this);
            Destroy(gameObject);
        }
    }
}
