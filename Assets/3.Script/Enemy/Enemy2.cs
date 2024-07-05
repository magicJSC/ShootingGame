using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyController, IAttack, IMove, IRotate
{
    public float BulletDamage => _bulletDamage;
    float _bulletDamage;

    public GameObject Bullet => _bullet;
    GameObject _bullet;

    public Vector2 MoveDirect => _moveDirect;
    Vector2 _moveDirect;

    public Vector3 MoveTarget => _moveTarget;
    Vector3 _moveTarget;

    public Vector2 LookDirect => _lookDirect;

    public Vector3 AttackDirect => _attackDirect;

    public float BulletSpeed => _bulletSpeed;
    float _bulletSpeed;

    public float AttackCool => _attackCool;
    float _attackCool;

    float _curTime = 0;

    Vector3 _attackDirect;

    Vector2 _lookDirect;

    Vector3 startPos;

    protected override void Init()
    {
        base.Init();
        _bulletDamage = enemySO.bulletDamage;
        _bullet = enemySO.bullet;
        _bulletSpeed = enemySO.bulletSpeed;
        _attackCool = enemySO.attackCool;
        startPos = transform.position;
        _moveTarget = transform.position + new Vector3(0, 0.5f, 0);
    }

    void Update()
    {
        Move();
        Rotate();
        Shot();
    }

    public override void CollideEvent()
    {

    }

    public void Move()
    {
        if (transform.position.y >= _moveTarget.y)
            _moveTarget = startPos + new Vector3(0, -0.5f, 0);
        else if (transform.position.y <= _moveTarget.y)
            _moveTarget = startPos + new Vector3(0, 0.5f, 0);
        _moveDirect = (_moveTarget - transform.position).normalized;
        rigid.velocity = MoveDirect * Speed;
    }

    public void Rotate()
    {
        _lookDirect = (player.transform.position - transform.position).normalized;
        float rot = Mathf.Atan2(-LookDirect.y, -LookDirect.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 270);
    }

    public void Shot()
    {
        if (_curTime < AttackCool)
        {
            _curTime += Time.deltaTime;
            return;
        }

        _curTime = 0;
        _attackDirect = (player.transform.position - transform.position).normalized;

        GameObject bullet = Instantiate(Bullet);
        bullet.GetComponent<Rigidbody2D>().velocity = _attackDirect * BulletSpeed;

        float rot = Mathf.Atan2(-AttackDirect.y, -AttackDirect.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        bullet.transform.position = transform.position;
        bullet.GetComponent<IBullet>().GetDamage(BulletDamage);
    }
}
