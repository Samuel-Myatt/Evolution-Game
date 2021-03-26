using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MonoBehaviour
{

    public Transform focus;
    private Rigidbody2D rb;
    Vector2 movement;
    public float timeBetweenAttacks = 2f;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = focus.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
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
        if (other.transform.tag == "Egg")
        {
            timeBetweenAttacks -= Time.deltaTime;
            if (timeBetweenAttacks <= 0)
            {
                Debug.Log("Attack");
                other.GetComponent<EggController>().TakeDamage(GetComponent<EnemyController>().dmg);
                timeBetweenAttacks = 2f;

            }
        }
        if (other.transform.tag == "Player")
        {
            timeBetweenAttacks -= Time.deltaTime;
            if (timeBetweenAttacks <= 0)
            {
                Debug.Log("Attack");
                other.GetComponent<PlayerController>().TakeDamage(GetComponent<EnemyController>().dmg);
                timeBetweenAttacks = 2f;
            }
        }
    }
}

