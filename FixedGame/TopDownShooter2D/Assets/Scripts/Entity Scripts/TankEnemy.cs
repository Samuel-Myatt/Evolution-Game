using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    public GameObject thisEnemy;
    public GameObject enemy;
    public float duration = 4f;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public bool dead= false;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(thisEnemy.GetComponent<EnemyController>().dead == true)
        {
            StartCoroutine(explode());
        }
    }

    IEnumerator explode()
    {

        yield return new WaitForSeconds(duration);
        
        Instantiate(enemy, point1.position, transform.rotation);
        Instantiate(enemy, point2.position, transform.rotation);
        Instantiate(enemy, point3.position, transform.rotation);
        Instantiate(enemy, point4.position, transform.rotation);
        Destroy(thisEnemy);

        

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
