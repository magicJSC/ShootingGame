using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 배경 움직이는 코드
/// </summary>
public class Background : MonoBehaviour
{
    public int speed;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x <= -18)
        {
            transform.position = Vector3.zero;
        }
    }
}
