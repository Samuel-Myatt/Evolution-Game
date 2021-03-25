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

    public float dashDistance;
    private float dashCoolDown = 1f;

    public int skillPoints = 0;
    public bool dashUnlocked = false;
    bool dashing = false;

    

   
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
        if (Input.GetKeyDown(KeyCode.LeftShift)&& dashUnlocked)
        {
            dashing = true;
        }
    }
    void FixedUpdate()
    {
        HandleMovement();

        if (dashing)
        {
            DashAbility();
        }


    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void HandleMovement()
    {

        Vector2 lookDirection = mouseAim - rb.position;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

        
    }
    

    public void DashAbility()
    {
       Debug.Log("Dash");
       dashDistance = 100f;
       rb.MovePosition(rb.position + movement * dashDistance * Time.fixedDeltaTime);
        dashing = false;
    }
}
