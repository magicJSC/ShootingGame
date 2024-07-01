using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    public int HP { get; set; }

    public float Speed { get; set; }

    public void ApplyDamage(IBullet bullet);
}

public interface IPlayer : ICharacter
{

}

public interface IEnemy : ICharacter
{
    public float Damge { get; set; }
    public float RushDamage { get; set; }
}

public interface IBullet 
{
    public int Damage { get; set; }
}

public interface IAttack
{
    public void Shot();

    public GameObject Bullet { get; set; }
}

public interface IMove
{
    public void Move();
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
