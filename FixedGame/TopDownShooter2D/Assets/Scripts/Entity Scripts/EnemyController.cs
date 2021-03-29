using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;

    public float maxHealth = 100f;

    public float dmg = 25f;

    public int pointsOnDeath;

    private int Flash = 0;


    public bool dead = false;
    public GameObject thisObject;
    [SerializeField]
    GameObject hud;




    private void Start()
    {
        hud = GameObject.Find("Canvas");
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

        thisObject.GetComponent<Renderer>().material.color = Color.red;
        Flash = 0;
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
            SoundManager.PlaySound("DeathSound");
            hud.GetComponent<SkillTreeUI>().levelPoints += pointsOnDeath;
            Destroy(gameObject);

        }
        if (health <= 0 && thisObject.tag == "EnemyTank")
        {
            hud.GetComponent<SkillTreeUI>().levelPoints += pointsOnDeath;
            dead = true;
        }

        if (Flash > 25)
        {
            thisObject.GetComponent<Renderer>().material.color = Color.white;
        }
        Flash++;
    }




    /* void DealDamage()
    {
        timeBetweenAttacks -= Time.deltaTime;
        if(timeBetweenAttacks <= 0)
        {

        }
    }*/
}
