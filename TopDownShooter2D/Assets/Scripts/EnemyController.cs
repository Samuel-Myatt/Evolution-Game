using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    
    public float maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }
    float calculateHealth()
    {
        return health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
