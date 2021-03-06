using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public float health;

    public float maxHealth = 100f;

    private void Start()
    {
        
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
