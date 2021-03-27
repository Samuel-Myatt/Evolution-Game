using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform weaponFirePoint;
    public float bulletForce = 20f;
    public GameObject gameObject;


    public GameObject chargedBullet;
    public bool chargedBulletUnlocked = false;
    private float chargeTime = 0f;
    public float bulletForceCharged = 40f;

    void Update()
    {
        if (Input.GetButton("Fire1"))//If Fire1 (mouse 1) is down...
        {
            chargeTime += Time.deltaTime;//Increase chargeTime.
        }

        if (Input.GetButtonUp("Fire1") && gameObject.tag == "Player")//If Fire1 is released...
        {
            if (chargeTime < 1f || chargedBulletUnlocked == false)//If charged for less than 1 second OR charged bullets have not been unlocked yet...
            {
                Fire();//Normal bullet.
            }
            else//If charged and unlocked...
            {
                ChargeFire();//Charged bullet.
            }

            chargeTime = 0f;//Reset chargeTime.
        }
    }
    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    public void FireEnemy()
    {
        GameObject newBullet = Instantiate(bullet, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    void ChargeFire()
    {
        GameObject newBullet = Instantiate(chargedBullet, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * bulletForceCharged, ForceMode2D.Impulse);
    }
}
