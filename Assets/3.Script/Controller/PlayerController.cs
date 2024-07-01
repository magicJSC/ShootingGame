using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 플레이어 제어 코드
/// </summary>
public class PlayerController : BaseController,ICharacter
{
    public float speed;

    Rigidbody2D _rigid;
    Vector2 _dir;


    [field:SerializeField]
    public int HP { get; set; }

    protected override void Init()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue input)
    {
        _dir = input.Get<Vector2>();
        _rigid.velocity = _dir*speed;
    }

    void OnShot()
    {

    }

    public void ApplyDamage(IBullet bullet)
    {
        HP -= bullet.Damage;
    }
}
