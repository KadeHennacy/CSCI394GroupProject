using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public Camera sceneCam;
    public float projectileForce = 20f;
    public float fireRate = 60f;
    public float damage = 1f;
    private float lastFired;
    private AudioSource shootingSound;

    // Update is called once per frame
    void Start()
    {
        shootingSound = GetComponent<AudioSource>();
        lastFired = 60 / fireRate;
    }
    void FixedUpdate()
    {
        lastFired += Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            if(lastFired > 60 / fireRate)
            {
                lastFired = 0f;
                Shoot();
            }
            
        }
    }
    //13:23 to find firepoint
    void Shoot()
    {
       GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
       shootingSound.Play();
    }
}
