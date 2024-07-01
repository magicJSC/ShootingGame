using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 제어 코드
/// </summary>
public class EnemyController : BaseController, IEnemy
{
    [field : SerializeField]
    public int HP { get ; set; }
    [field : SerializeField]
    public float Speed { get; set; }
    public float Damge { get; set; }
    public float RushDamage { get; set; }

    protected Rigidbody2D _rigid;

    protected override void Init()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void ApplyDamage(IBullet bullet)
    {
        HP -= bullet.Damage;
        if (HP <= 0)
            Destroy(gameObject);
    }
}
