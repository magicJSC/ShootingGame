using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetDamage
{
    public void ApplyDamage(ICollisionDamage bullet);
}

public interface ICharacter : IGetDamage
{
    public float HP { get; }

    public float Speed { get; }
}

public interface IPlayer : ICharacter
{
    
    public float Damage { get;}

    public GameObject RedBullet { get; }
    public GameObject GreenBullet { get; }

    public float AttackCool { get; }

    public float BulletSpeed { get; }
}

public interface IEnemy : ICharacter,ICollisionDamage
{
    public ColorTypeSO ColortypeSO { get; }
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
