using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject firePoint;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.name.Contains("Player")){
            Destroy(gameObject);
        }
    }
}
