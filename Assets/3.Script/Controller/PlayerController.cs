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

    bool canShot;

    [field:SerializeField]
    public float HP { get; set; }

    [field: SerializeField]
    public float Speed { get; set; }

    [field:SerializeField]
    public float Damage { get;set; }

    [field:SerializeField]
    public GameObject Bullet { get; set; }

    [field: SerializeField]
    public float AttackCool { get; set; }

    float _attackCurTime = 0;

    [field: SerializeField]
    public float BulletSpeed { get; set; }

    protected override void Init()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _attackCurTime = AttackCool;
    }

    void Update()
    {
        Shot();
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

    void Shot()
    {
        if (_attackCurTime <= AttackCool)
        {
            _attackCurTime += Time.deltaTime;
            return;
        }
        if (!canShot)
            return;

        _attackCurTime = 0;

        GameObject bullet = Instantiate(Bullet);
        bullet.GetComponent<Rigidbody2D>().velocity = lookDirect * BulletSpeed;

        float rot = Mathf.Atan2(-lookDirect.y, -lookDirect.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        bullet.transform.position = transform.position;
        bullet.GetComponent<PlayerBullet>().CollisionDamage = Damage;
    }

    void OnStartShot()
    {
        canShot = true;
    }

    void OnCancelShot()
    {
        canShot = false;
    }

    public void ApplyDamage(ICollisionDamage bullet)
    {
        HP -= bullet.CollisionDamage;
        if (HP <= 0)
            Debug.Log("플레이어 사망");
    }
}
