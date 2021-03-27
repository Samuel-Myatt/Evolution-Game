using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float dmg = 50f;
    public GameObject bullet;
   // public GameObject FireWeaponPoint;
   // public Transform reflector;

    //public float newBulletForce;

    public float lifeDuration = 2f;//2 seconds.
    private float lifeTimer;

    Rigidbody2D rb;
    void Start()
    {
        lifeTimer = lifeDuration;
        rb = this.GetComponent<Rigidbody2D>();

        //newBulletForce = FireWeaponPoint.GetComponent<FireWeapon>().bulletForce;
    }
    void Update()
    {
        
        lifeTimer -= Time.deltaTime;//Decrease lifeTimer over time.
        if(lifeTimer <= 0f)//If bullet has run out of life time...
        {
            Destroy(bullet);//Destroy self.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy"|| other.transform.tag =="EnemyTank")
        {
            
            other.GetComponent<EnemyController>().TakeDamage(dmg);
            Destroy(bullet);
        }
        if (other.transform.tag == "Player")
        {
            
            other.GetComponent<PlayerController>().TakeDamage(dmg);
            Destroy(bullet);
        }
        if (other.transform.tag == "Reflector")
        {
            Destroy(bullet);// rb.AddForce(reflector.up * -newBulletForce, ForceMode2D.Impulse);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);
    }
}
