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
public abstract class EnemyController : BaseController, IEnemy
{
    public EnemySO enemySO;
    public ColorTypeSO ColortypeSO => colortypeSO;
    [SerializeField]
    ColorTypeSO colortypeSO;

    public float HP { get => _hp; }
    float _hp;

    public float Speed { get => _speed; }
    float _speed;

    public float CollisionDamage { get => _collisonDamage; }


    float _collisonDamage;

    public Transform target;

    protected Rigidbody2D rigid;

    protected override void Init()
    {
        rigid = GetComponent<Rigidbody2D>();
        _hp = enemySO.hp;
        _speed = enemySO.speed;
        _collisonDamage = enemySO.collisionDamage;
    }

    public void ApplyDamage(ICollisionDamage bullet)
    {
        _hp -= bullet.CollisionDamage;
        if (HP <= 0)
            Destroy(gameObject);
    }

    public abstract void CollideEvent();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPlayer>(out var player))
        {
            player.ApplyDamage(this);
            CollideEvent();
        }
    }
}
