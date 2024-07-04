using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionDamage
{
    public float CollisionDamage { get; }
}

public interface IBullet : ICollisionDamage
{
    public void GetDamage(float damage);
}

public class BulletController : BaseController
{

    protected override void Init()
    {
        
    }
}
