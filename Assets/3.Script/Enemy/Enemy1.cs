using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyController,IMove,IRotate
{
    public Vector2 MoveDirect => _moveDirect;
    Vector2 _moveDirect;

    public Vector2 LookDirect => _lookDirect;

    public Vector3 MoveTarget => _moveTarget;
    Vector3 _moveTarget;

    Vector2 _lookDirect;

    void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        _moveDirect = (player.transform.position - transform.position).normalized;
        rigid.velocity = MoveDirect * Speed;
    }

    public void Rotate()
    {
        _lookDirect = (player.transform.position - transform.position).normalized;
        float rot = Mathf.Atan2(-LookDirect.y, -LookDirect.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 270);
    }

    public override void CollideEvent()
    {
        Destroy(gameObject);  
    }
}
