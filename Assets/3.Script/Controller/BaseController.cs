using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    public int HP { get; set; }

    public void ApplyDamage(IBullet bullet);
}

public interface IBullet 
{
    public int Damage { get; set; }
}

public interface IAttack
{
    public void Shot();
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
