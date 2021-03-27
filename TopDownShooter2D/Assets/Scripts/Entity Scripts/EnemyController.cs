using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    
    public float maxHealth = 100f;

    public float dmg = 25f;
<<<<<<< Updated upstream
=======
<<<<<<< HEAD

    public bool dead = false;
    public GameObject thisObject;
=======
>>>>>>> 99ac46c2195f20f72f4c34396b8825d7b2a4bf80
>>>>>>> Stashed changes



    
    

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
        if (health <= 0 && thisObject.tag != "EnemyTank")
        {
            
            Destroy(gameObject);

        }
        if(health<= 0 && thisObject.tag == "EnemyTank")
        {
            dead = true;
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
