using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;

    Vector2 movement;
    Vector2 mouseAim;

    public Rigidbody2D rb;

    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        mouseAim = camera.ScreenToWorldPoint(Input.mousePosition);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        Vector2 lookDirection = mouseAim - rb.position;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
