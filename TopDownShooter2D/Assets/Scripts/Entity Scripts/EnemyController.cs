using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    
    public float maxHealth = 100f;

    public float dmg = 25f;
    public float speed = 5f;
    public Transform egg;
    private Rigidbody2D rb;
    Vector2 movement;
    public float timeBetweenAttacks = 2f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = maxHealth;
    }
    float calculateHealth()
    {
        //used for health bars
        return health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 direction = egg.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg- 90;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag== "Egg")
        {
            timeBetweenAttacks -= Time.deltaTime;
            if (timeBetweenAttacks <= 0)
            {
                Debug.Log("Attack");
                other.GetComponent<EggController>().TakeDamage(dmg);
                timeBetweenAttacks = 2f;

            }
        }
        if (other.transform.tag == "Player")
        {
            timeBetweenAttacks -= Time.deltaTime;
            if (timeBetweenAttacks <= 0)
            {
                Debug.Log("Attack");
                other.GetComponent<PlayerController>().TakeDamage(dmg);
                timeBetweenAttacks = 2f;
            }
        }
    }
   /* void DealDamage()
    {
        timeBetweenAttacks -= Time.deltaTime;
        if(timeBetweenAttacks <= 0)
        {

        }
    }*/
}
