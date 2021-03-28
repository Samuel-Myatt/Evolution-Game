using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Transform weaponFirePoint;

    //Normal bullet.
    public GameObject bullet;
    public float bulletForce = 20f;

    public GameObject gameObject;

    //Charged bullet.
    public GameObject chargedBullet;
    public bool chargedBulletUnlocked = false;
    private float chargeTime = 0f;
    public float chargeTimeNeeded = 1f;
    public float chargedBulletForce = 40f;

    //DoT bullet.
    public GameObject DOTBullet;
    public bool DOTBulletUnlocked = false;
    public float DOTBulletForce = 20f;

    void Update()
    {
        if (Input.GetButton("Fire1"))//If Fire1 (mouse 1) is down...
        {
            chargeTime += Time.deltaTime;//Increase chargeTime.
        }

        if (Input.GetButtonUp("Fire1") && gameObject.tag == "Player")//If Fire1 is released...
        {
            if (chargeTime < chargeTimeNeeded || chargedBulletUnlocked == false)//If charged for less than 1 second OR charged bullets have not been unlocked yet...
            {
                Fire(bullet, bulletForce);//Normal bullet.
            }
            else//If charged and unlocked...
            {
                Fire(chargedBullet, chargedBulletForce);//Charged bullet.
            }

            chargeTime = 0f;//Reset chargeTime.
        }

        if (Input.GetButtonDown("Fire2") && DOTBulletUnlocked)//If Fire2 (mouse 2) is pressed...
        {
            Debug.Log("RightClick");
            Fire(DOTBullet, DOTBulletForce);//DoT bullet.
        }
    }
    void Fire(GameObject bulletType, float forceType)
    {
        GameObject newBullet = Instantiate(bulletType, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * forceType, ForceMode2D.Impulse);
    }
    public void FireEnemy()
    {
        GameObject newBullet = Instantiate(bullet, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}