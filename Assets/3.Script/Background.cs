using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public int speed;
    void Update()
    {
        transform.position += Vector3.left * speed;
        if(transform.position.x <= -18)
        {
            transform.position = Vector3.zero;
        }
    }
}
