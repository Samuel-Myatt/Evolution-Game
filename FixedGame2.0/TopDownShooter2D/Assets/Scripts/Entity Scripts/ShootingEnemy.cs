using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float stopDis;
    public float retreatDis;

    public float maxTimeBetweenShots;
    private float timeBetweenShots;

    public GameObject player;
    private Transform focus;

    //public GameObject bullet;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        focus = player.transform;
        timeBetweenShots = maxTimeBetweenShots;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf)//If the player is even alive.
        {
            Vector3 direction = focus.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            rb.rotation = angle;
            direction.Normalize();
            if (Vector2.Distance(transform.position, focus.position) > stopDis)
            {
                transform.position = Vector2.MoveTowards(transform.position, focus.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, focus.position) < stopDis && Vector2.Distance(transform.position, focus.position) > retreatDis)
            {
                transform.position = this.transform.position;

            }
            else if (Vector2.Distance(transform.position, focus.position) < retreatDis)
            {
                transform.position = Vector2.MoveTowards(transform.position, focus.position, -speed * Time.deltaTime);
            }

            if (timeBetweenShots <= 0)
            {
                this.GetComponent<FireWeapon>().FireEnemy();
                timeBetweenShots = maxTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }
}
    