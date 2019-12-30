using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) )
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
