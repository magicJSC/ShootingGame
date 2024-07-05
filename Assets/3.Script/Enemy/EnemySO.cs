using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName ="SO/EnemySO")]
public class EnemySO : ScriptableObject
{
    public float hp;
    public float speed;
    public float collisionDamage;
    public float score;

    [Header("Attack")]
    public float bulletDamage;
    public float bulletSpeed;
    public float attackCool;
    public GameObject bullet;
}
