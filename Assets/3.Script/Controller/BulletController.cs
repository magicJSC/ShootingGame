using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionDamage
{
    public float CollisionDamage { get; set; }
}

public class BulletController : BaseController
{
    protected override void Init()
    {
        
    }
}
