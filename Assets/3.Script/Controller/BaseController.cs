using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetDamage
{
    public void ApplyDamage(ICollisionDamage bullet);
}

public interface ICharacter : IGetDamage
{
    public float HP { get; set; }

    public float Speed { get; set; }
}

public interface IPlayer : ICharacter
{
    
    public float Damage { get; set; }

    public GameObject Bullet { get; set; }

    public float AttackCool { get; set; }

    public float BulletSpeed { get; set; }
}

public interface IEnemy : ICharacter,ICollisionDamage
{
    
}

/// <summary>
/// 모든 Controller의 부모 코드
/// </summary>
public abstract class BaseController : MonoBehaviour
{
    protected abstract void Init();

    private void Start()
    {
        Init();
    }
}
