using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float dmg = 50f;
    public GameObject bullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
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
