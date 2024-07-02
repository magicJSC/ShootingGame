using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 총알 제어 코드
/// </summary>
public class PlayerBullet : MonoBehaviour, IBullet
{
    public int Damage { get ; set ; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
            enemy.ApplyDamage(this);
            Destroy(gameObject);
        }
    }
}
