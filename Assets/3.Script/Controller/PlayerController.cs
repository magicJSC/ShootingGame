using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 플레이어 제어 코드
/// </summary>
public class PlayerController : BaseController,IPlayer
{

    Rigidbody2D _rigid;
    Vector2 _dir;


    [field:SerializeField]
    public int HP { get; set; }
    [field: SerializeField]
    public float Speed { get; set; }

    protected override void Init()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue input)
    {
        _dir = input.Get<Vector2>();
        _rigid.velocity = _dir * Speed;
    }

    void OnRotate(InputValue input)
    {
        Vector3 mousePos = input.Get<Vector2>();
        if (mousePos == Vector3.zero)
            return;

        Vector3 dir = (mousePos - transform.position).normalized;
        transform.up = dir;
    }

    void OnShot()
    {

    }

    public void ApplyDamage(IBullet bullet)
    {
        HP -= bullet.Damage;
        if (HP <= 0)
            Debug.Log("플레이어 사망");
    }
}
