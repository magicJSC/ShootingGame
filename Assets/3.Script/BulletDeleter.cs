using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeleter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IBullet>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
