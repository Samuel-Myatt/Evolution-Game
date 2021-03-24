using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform weaponFirePoint;
    public float bulletForce = 20f;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        } 
    }
    void Fire()
    {
        GameObject newBullet = Instantiate(bullet, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
