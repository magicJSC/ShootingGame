using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 플레이어의 총알 제어 코드
/// </summary>
public class PlayerBullet : MonoBehaviour, ICollisionDamage
{
    public float CollisionDamage { get; set; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IEnemy>(out var enemy))
        {
            enemy.ApplyDamage(this);
            Destroy(gameObject);
        }
    }
}
