using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionDamage
{
    public int CollisionDamage { get; set; }
}

public class BulletController : BaseController
{
    protected override void Init()
    {
        
    }
}
