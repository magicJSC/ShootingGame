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
    Vector2 moveDirect;
    Vector2 lookDirect;


    [field:SerializeField]
    public int HP { get; set; }
    [field: SerializeField]
    public float Speed { get; set; }

    [field:SerializeField]
    public GameObject Bullet { get; set; }
    [field: SerializeField]
    public float attackCool { get; set; }
    [field: SerializeField]
    public float bulletSpeed { get; set; }

    protected override void Init()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue input)
    {
        moveDirect = input.Get<Vector2>();
        _rigid.velocity = moveDirect * Speed;
    }

    void OnRotate(InputValue input)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(input.Get<Vector2>());

        lookDirect = (mousePos - transform.position).normalized;
        float rot = Mathf.Atan2(-lookDirect.y,-lookDirect.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);
    }

    void OnShot()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.GetComponent<Rigidbody2D>().velocity = lookDirect * bulletSpeed;
        float rot = Mathf.Atan2(-lookDirect.y, -lookDirect.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    public void ApplyDamage(IBullet bullet)
    {
        HP -= bullet.Damage;
        if (HP <= 0)
            Debug.Log("플레이어 사망");
    }
}
