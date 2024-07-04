using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 플레이어의 총알 제어 코드
/// </summary>
public class PlayerBullet : MonoBehaviour, IBullet
{
    public ColorTypeSO colortypeSO;

    public float CollisionDamage { get => _collisionDamage; }
    float _collisionDamage;

    public void GetDamage(float damage)
    {
        _collisionDamage = damage;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IEnemy>(out var enemy))
        {
            if (enemy.ColortypeSO == colortypeSO)
                enemy.ApplyDamage(this);
            Destroy(gameObject);
        }
    }
}
