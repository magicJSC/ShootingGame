using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 플레이어 제어 코드
/// </summary>
public class PlayerController : BaseController,IPlayer
{
    Rigidbody2D rigid;

    Vector2 mousePositon;
    Vector2 moveDirect;
    Vector2 lookDirection;

    bool canShot;
    bool isDie;

    public float HP => hp;
    [SerializeField]
    float hp;

    public float Speed  => speed; 
    [SerializeField]
    private float speed;

    public float Damage => damage; 
    [SerializeField]
    float damage;
    
    public float AttackCool => attackCool; 
    [SerializeField]
    private float attackCool;

    float attackCurTime = 0;

    
    public float BulletSpeed => bulletSpeed;
    [SerializeField]
    private float bulletSpeed;

    public GameObject RedBullet => redBullet;
    [SerializeField]
    GameObject redBullet;

    public GameObject GreenBullet => greenBullet;
    [SerializeField]
    GameObject greenBullet;

    private GameObject usingBullet;
    



    protected override void Init()
    {
        rigid = GetComponent<Rigidbody2D>();
        attackCurTime = AttackCool;
        usingBullet = RedBullet;

        GameManager.Instance.player = transform;
    }

    void Update()
    {
        if (isDie)
            return;
        Shot();
        Rotate();
    }

    void OnMove(InputValue input)
    {
        moveDirect = input.Get<Vector2>();
        rigid.velocity = moveDirect * Speed;
    }

    void OnGetMousePos(InputValue input)
    {
        mousePositon = input.Get<Vector2>();
    }

    void Rotate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePositon);

        lookDirection = (mousePos - transform.position).normalized;
        float rot = Mathf.Atan2(-lookDirection.y,-lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);
    }

    void Shot()
    {
        if (attackCurTime <= AttackCool)
        {
            attackCurTime += Time.deltaTime;
            return;
        }
        if (!canShot)
            return;

        attackCurTime = 0;

        GameObject bullet = Instantiate(usingBullet);
        bullet.GetComponent<Rigidbody2D>().velocity = lookDirection * BulletSpeed;

        float rot = Mathf.Atan2(-lookDirection.y, -lookDirection.x) * Mathf.Rad2Deg;
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
        if (isDie)
            return;
        hp -= bullet.CollisionDamage;
        if (HP <= 0)
            Die();
    }

    public void Die()
    {
       isDie = true;
        Debug.Log("플레이어 사망");
    }
}
