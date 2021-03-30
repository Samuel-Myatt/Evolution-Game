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
    public float chargeTime = 0f;
    public float chargeTimeNeeded = 0.5f;
    public float chargedBulletForce = 40f;

    //DoT bullet.
    public GameObject DOTBullet;
    public bool DOTBulletUnlocked = false;
    public float DOTBulletForce = 20f;

    //Multi bullets.
    public bool multiBulletUnlocked = false;
    public int multiBulletAmount = 2;
    public float multiBulletSpread = 5f;

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
                //Normal bullet.
                if (multiBulletUnlocked) FireMulti(bullet, bulletForce, multiBulletAmount, multiBulletSpread);
                else Fire(bullet, bulletForce);
            }
            else//If charged and unlocked...
            {
                //Charged bullet.
                if (multiBulletUnlocked) FireMulti(chargedBullet, chargedBulletForce, multiBulletAmount, multiBulletSpread);
                else Fire(chargedBullet, chargedBulletForce);
            }

            chargeTime = 0f;//Reset chargeTime.
        }

        if (Input.GetButtonDown("Fire2") && DOTBulletUnlocked)//If Fire2 (mouse 2) is pressed...
        {
            //DoT bullet.
            if (multiBulletUnlocked) FireMulti(DOTBullet, DOTBulletForce, multiBulletAmount, multiBulletSpread);
            else Fire(DOTBullet, DOTBulletForce);
        }
    }
    void Fire(GameObject bulletObject, float force)
    {
        SoundManager.PlaySound("PlayerShoot");
        GameObject newBullet = Instantiate(bulletObject, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * force, ForceMode2D.Impulse);
    }
    void FireMulti(GameObject bulletObject, float force, int amount, float spreadWhole)
    {
        if(amount != 1)//Prevent dividing by zero.
        {
            float spreadBtwnBullets = spreadWhole / (amount - 1);
            float startAngle = 90f + weaponFirePoint.rotation.eulerAngles.z + spreadWhole * -0.5f;
            float angle;

            for (int i = 0; i < amount; i++)
            {
                angle = startAngle + spreadBtwnBullets * i;

                GameObject newBullet = Instantiate(bulletObject, weaponFirePoint.position, weaponFirePoint.rotation);
                Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
                Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(dir * force, ForceMode2D.Impulse);
            }
        }
        else
        {
            Debug.Log("Cannot devide by zero! Single bullet not accepted.");
        }
    }
    public void FireEnemy()
    {
        GameObject newBullet = Instantiate(bullet, weaponFirePoint.position, weaponFirePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponFirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}