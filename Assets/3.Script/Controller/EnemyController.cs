using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    public void Shot();
    public float BulletDamage { get; set; }
    public GameObject Bullet { get; set; }
}

public interface IMove
{
    Vector2 moveDirect { get; set; }
    public void Move();
}

public interface IRotate
{
    Vector2 lookDirect { get; set; }
    public void Rotate();
}

/// <summary>
/// 적 제어 코드
/// </summary>
public class EnemyController : BaseController, IEnemy
{
    [field : SerializeField]
    public float HP { get ; set; }

    [field : SerializeField]
    public float Speed { get; set; }

    [field: SerializeField]
    public float CollisionDamage { get; set; }

    [field: SerializeField]
    public Transform target;

    protected Rigidbody2D _rigid;

    protected override void Init()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void ApplyDamage(ICollisionDamage bullet)
    {
        HP -= bullet.CollisionDamage;
        if (HP <= 0)
            Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPlayer>(out var player))
        {
            player.ApplyDamage(this);
            Destroy(gameObject);
        }
    }
}
