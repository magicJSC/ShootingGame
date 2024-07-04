using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyController,IMove,IRotate
{
    public Vector2 moveDirect { get; set; }
    public Vector2 lookDirect { get; set; }

    void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        moveDirect = (target.transform.position - transform.position).normalized;
        rigid.velocity = moveDirect * Speed;
    }

    public void Rotate()
    {
        lookDirect = (target.transform.position - transform.position).normalized;
        float rot = Mathf.Atan2(-lookDirect.y, -lookDirect.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 270);
    }

    public override void CollideEvent()
    {
        Destroy(gameObject);  
    }
}
