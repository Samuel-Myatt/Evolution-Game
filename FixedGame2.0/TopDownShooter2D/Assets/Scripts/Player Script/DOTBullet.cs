using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTBullet : MonoBehaviour
{
    public float dmg = 10f;
    public float DOT = 30f;
    public float numberOfDOT = 3f;
    public float DOTDelay = 1f;
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
        if (lifeTimer <= 0f)//If bullet has run out of life time...
        {
            Destroy(bullet);//Destroy self.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().TakeDamage(dmg);
            other.GetComponent<EnemyController>().TakeDamageOverTime(DOT, numberOfDOT, DOTDelay);
            Debug.Log("DOT HIT ENEMY");
            Destroy(bullet);
        }
        Destroy(bullet);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);
    }
}