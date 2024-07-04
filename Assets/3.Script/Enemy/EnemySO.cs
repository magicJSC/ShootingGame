using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName ="SO/EnemySO")]
public class EnemySO : ScriptableObject
{
    public float hp;
    public float bulletDamage;
    public float speed;
    public GameObject bullet;
    public float collisionDamage;
}
