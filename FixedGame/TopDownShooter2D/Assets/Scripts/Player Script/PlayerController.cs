using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;

    float horizontal;
    float vertical;
    Vector2 mouseAim;

    public Rigidbody2D rb;

    public float health;
    public float maxHealth = 100f;

    public float speed = 2f;

    public float countdown = 5f;
    public float startCountdownTime = 5f;

    public float bufferTimer;
    public float startBufferTimer;


    public int skillPoints = 0;

    public bool dashUnlocked = false;

    //New dash (not blink) variables. A large amount of the code realting to dashing was created with help from Bardent https://www.youtube.com/watch?v=ylsWcc4IP3E&ab_channel=Bardent
    private bool canMove = true;//Needed to prevent player movement while dashing.
    private bool canTurn = true;//Needed to prevent player turning while dashing.
    private bool isDashing = false;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;
    private float dashTimeLeft;
    private Vector3 lastImagePos;
    private float lastDash = -100f;//Time since last dash (for cooldown). Set to -100 so dash is available as soon as game starts.

    public bool reflectorActive = false;
    public bool reflectorUnlocked = false;

    public GameObject reflector;

    
    private void Start()
    {
        health = maxHealth;
        countdown = startCountdownTime;
    }
    void Update()
    {
        if (canTurn)
        {
            mouseAim = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUnlocked)
        {
            AttemptToDash();
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

        CheckDash();
    }
    void FixedUpdate()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        Vector2 lookDirection = mouseAim - rb.position;

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
    private void AttemptToDash()
    {
        if(lastDash + dashCoolDown < Time.time)
        {
            isDashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;

            PlayerAfterImagePool.Instance.GetFromPool();//Place an after image.
            lastImagePos = transform.position;
        }
    }
    private void CheckDash()//For setting dash velocity and checking if we should be dashing or if we should stop.
    {
        if (isDashing)
        {
            if(dashTimeLeft > 0)
            {
                canMove = false;
                canTurn = false;
                rb.AddForce(rb.velocity * dashSpeed);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(Vector3.Distance(transform.position, lastImagePos)) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();//Place an after image.
                    lastImagePos = transform.position;
                }
            }

            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                canMove = true;
                canTurn = true;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
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
