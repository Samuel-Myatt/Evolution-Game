using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float dmg = 50f;
    public GameObject bullet;

    public float lifeDuration = 2f;//2 seconds.
    private float lifeTimer;

    void Start()
    {
        lifeTimer = lifeDuration;
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
        if (other.transform.tag == "Enemy")
        {
            Destroy(bullet);
            other.GetComponent<EnemyController>().TakeDamage(dmg);
            Destroy(bullet);
        }
        Destroy(bullet);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);
    }
}
