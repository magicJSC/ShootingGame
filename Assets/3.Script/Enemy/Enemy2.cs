using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyController, IAttack, IMove, IRotate
{
    public float BulletDamage => bulletDamage;
    float bulletDamage;

    public GameObject Bullet => bullet;
    GameObject bullet;

    public Vector2 MoveDirect => moveDirect;
    Vector2 moveDirect;

    public Vector3 MoveTarget => moveTarget;
    Vector3 moveTarget;

    public Vector2 LookDirect => lookDirect;
    Vector2 lookDirect;

    public Vector3 AttackDirect => attackDirect;
    Vector3 attackDirect;

    public float BulletSpeed => bulletSpeed;
    float bulletSpeed;

    public float AttackCool => attackCool;
    float attackCool;

    float curTime = 0;



    Vector3 startPos;

    protected override void Init()
    {
        base.Init();
        bulletDamage = enemySO.bulletDamage;
        bullet = enemySO.bullet;
        bulletSpeed = enemySO.bulletSpeed;
        attackCool = enemySO.attackCool;
        startPos = transform.position;
        moveTarget = transform.position + new Vector3(0, 0.5f, 0);
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
        moveTarget = startPos + (moveTarget - transform.position).normalized * 0.5f;
        moveDirect = (moveTarget - transform.position).normalized;
        rigid.velocity = MoveDirect * Speed;
    }

    public void Rotate()
    {
        lookDirect = (player.transform.position - transform.position).normalized;
        float rot = Mathf.Atan2(-LookDirect.y, -LookDirect.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 270);
    }

    public void Shot()
    {
        if (curTime < AttackCool)
        {
            curTime += Time.deltaTime;
            return;
        }

        curTime = 0;
        attackDirect = (player.transform.position - transform.position).normalized;

        GameObject bullet = Instantiate(Bullet);
        bullet.GetComponent<Rigidbody2D>().velocity = attackDirect * BulletSpeed;

        float rot = Mathf.Atan2(-AttackDirect.y, -AttackDirect.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        bullet.transform.position = transform.position;
        bullet.GetComponent<IBullet>().GetDamage(BulletDamage);
    }
}
