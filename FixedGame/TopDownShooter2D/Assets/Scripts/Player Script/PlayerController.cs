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

    public float countdown = 5f;
    public float startCountdownTime = 5f;

    public float bufferTimer;
    public float startBufferTimer;


    public int skillPoints = 0;
    public bool dashUnlocked = false;
    bool dashing = false;
    public bool reflectorActive = false;
    public bool reflectorUnlocked = false;

    public GameObject reflector;

    [SerializeField] private LayerMask dashLayerMask;//Store which layers dash collides with objects on.


    private void Start()
    {
        health = maxHealth;
        countdown = startCountdownTime;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUnlocked)
        {
            dashing = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && reflectorUnlocked && bufferTimer >= startBufferTimer)
        {
            DeflectAbility();
        }
        if (reflectorActive)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0)
        {
            reflector.SetActive(false);
            reflectorActive = false;

            bufferTimer -= Time.deltaTime;
        }
        if (bufferTimer <= 0)
        {
            countdown = startCountdownTime;
            bufferTimer = startBufferTimer;
        }

        //Prevent overhealing.
        if (health > maxHealth)
        {
            health = maxHealth;
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
        Vector3 dashPosition = rb.position + movement * dashDistance * Time.fixedDeltaTime;//Determine dash position assuming no obstacles.

        RaycastHit2D raycastHit2D = Physics2D.Raycast(rb.position, movement, dashDistance, dashLayerMask);//Create a raycast from the player to the dash position on all layers included in dashLayerMask.
        if (raycastHit2D.collider != null)//If the raycast collides with anything...
        {
            dashPosition = raycastHit2D.point;//The dash position becomes the point of raycast collision (e.g. a wall).
        }

        rb.MovePosition(dashPosition);//Move player instantly to the dash position.
        dashing = false;
    }
    public void DeflectAbility()
    {


        if (countdown > 0)
        {
            reflector.SetActive(true);
            reflectorActive = true;
        }
        else
        {
            reflector.SetActive(false);

            reflectorActive = false;
        }
    }
}
