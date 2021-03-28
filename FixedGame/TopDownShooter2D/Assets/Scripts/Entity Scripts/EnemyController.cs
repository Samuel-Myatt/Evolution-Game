using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;

    public float maxHealth = 100f;

    public float dmg = 25f;




    public bool dead = false;
    public GameObject thisObject;








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
    public void TakeDamageOverTime(float DOT, float numberOfDOT, float delay)
    {
        StartCoroutine(TakeDamageOverTimeCoroutine(DOT, numberOfDOT, delay));
    }

    IEnumerator TakeDamageOverTimeCoroutine(float DOT, float numberOfDOT, float delay)
    {
        Debug.Log("In the IEnumerator babeeeeyy");
        for (int i = 0; i < numberOfDOT; i++)
        {
            yield return new WaitForSeconds(delay);//Wait 1 second.
            health -= DOT;
            Debug.Log("DOT DAMAGE");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && thisObject.tag != "EnemyTank")
        {

            Destroy(gameObject);

        }
        if (health <= 0 && thisObject.tag == "EnemyTank")
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