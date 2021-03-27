using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{
    public static bool paused = false;
    public GameObject skills;
    public GameObject player;
    public int levelPoints;
    public GameObject[] buttons;

    private void Start()
    {
        player.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                SkillTreeActive();
            }
        }
    }
    public void Resume()
    {
        skills.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void SkillTreeActive()
    {
        skills.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void UnlockDash()
    {
        Debug.Log("Clicked");
        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().dashUnlocked = true;
            levelPoints -= 1;
            Debug.Log("TheClick");
        }
    }
    public void IncreaseHealth()
    {

        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().maxHealth += 50;
            levelPoints -= 1;

        }
    }
    public void IncreaseSpeed()
    {

        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().speed += 2;
            levelPoints -= 1;

        }
    }
    public void IncreaseDashSize()
    {

        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().dashDistance += 20;
            levelPoints -= 1;

        }
    }
    public void Heal()
    {

        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().health += 25;
            levelPoints -= 1;

        }
    }
    public void UnlockReflector()
    {
        Debug.Log("Clicked");
        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().reflectorUnlocked = true;
            levelPoints -= 1;
            Debug.Log("TheClick");
        }
    }
    public void UnlockChargedShot()
    {
        Debug.Log("Clicked");
        if (levelPoints >= 1)
        {
            player.GetComponent<FireWeapon>().chargedBulletUnlocked = true;
            levelPoints -= 1;
            Debug.Log("TheClick");
        }
    }

}