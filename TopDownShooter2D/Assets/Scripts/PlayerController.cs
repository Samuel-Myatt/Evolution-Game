using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;

    Vector2 movement;
    Vector2 mouseAim;

    public Rigidbody2D rb;

    public float health;
    public float maxHealth = 100f;

    public float speed = 2f;

    private void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        mouseAim = camera.ScreenToWorldPoint(Input.mousePosition);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector2 lookDirection = mouseAim - rb.position;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
