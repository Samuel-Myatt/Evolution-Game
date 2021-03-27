using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    
    public float maxHealth = 100f;

    public float dmg = 25f;



    
    

    private void Start()
    {
  
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

        
    }
    

    
    
   /* void DealDamage()
    {
        timeBetweenAttacks -= Time.deltaTime;
        if(timeBetweenAttacks <= 0)
        {

        }
    }*/
}
