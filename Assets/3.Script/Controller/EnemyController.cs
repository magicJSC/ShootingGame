using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    public GameObject Bullet { get; }
    Vector3 AttackDirect { get; }
    public float BulletDamage { get; }
    public float BulletSpeed { get; }
    public float AttackCool { get; }
    public void Shot();
}

public interface IMove
{
    Vector2 MoveDirect { get; }
    Vector3 MoveTarget { get; }
    public void Move();

}

public interface IRotate
{
    Vector2 LookDirect { get; }
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

    public float HP => _hp;
    float _hp;

    public float Speed => _speed;
    float _speed;

    public float CollisionDamage => _collisonDamage;

    public float Score => _score;
    float _score;

    float _collisonDamage;

    public Transform player;

    protected Rigidbody2D rigid;

    protected override void Init()
    {
        rigid = GetComponent<Rigidbody2D>();
        _hp = enemySO.hp;
        _speed = enemySO.speed;
        _collisonDamage = enemySO.collisionDamage;
        _score = enemySO.score;
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

    public void Die()
    {
        GameManager.Instance.score = Score;
    }
}
