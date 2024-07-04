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

    Vector2 mousePositon;
    Vector2 moveDirect;
    Vector2 lookDirect;

    bool canShot;

    public float HP => _hp;
    [SerializeField]
    float _hp;

    public float Speed  => _speed; 
    [SerializeField]
    private float _speed;

    public float Damage => _damage; 
    [SerializeField]
    float _damage;
    
    public float AttackCool => _attackCool; 
    [SerializeField]
    private float _attackCool;

    float _attackCurTime = 0;

    
    public float BulletSpeed => _bulletSpeed; 

    public GameObject RedBullet => redBullet;
    [SerializeField]
    GameObject redBullet;
    public GameObject GreenBullet => greenBullet;
    [SerializeField]
    GameObject greenBullet;

    [SerializeField]
    private float _bulletSpeed;

    private GameObject usingBullet;


    protected override void Init()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _attackCurTime = AttackCool;
        usingBullet = RedBullet;
    }

    void Update()
    {
        Shot();
        Rotate();
    }

    void OnMove(InputValue input)
    {
        moveDirect = input.Get<Vector2>();
        _rigid.velocity = moveDirect * Speed;
    }

    void OnGetMousePos(InputValue input)
    {
        mousePositon = input.Get<Vector2>();
    }

    void Rotate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePositon);

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

        GameObject bullet = Instantiate(usingBullet);
        bullet.GetComponent<Rigidbody2D>().velocity = lookDirect * BulletSpeed;

        float rot = Mathf.Atan2(-lookDirect.y, -lookDirect.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        bullet.transform.position = transform.position;
        bullet.GetComponent<IBullet>().GetDamage(Damage);
    }

    void OnChangeBullet()
    {
        if (usingBullet == GreenBullet) 
            usingBullet = RedBullet;
        else
            usingBullet = GreenBullet;
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
        _hp -= bullet.CollisionDamage;
        if (HP <= 0)
            Debug.Log("플레이어 사망");
    }
}
