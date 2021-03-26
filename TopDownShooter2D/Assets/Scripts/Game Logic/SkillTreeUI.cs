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
        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().dashUnlocked = true;
            levelPoints -= 1;
            
        }
    }
    public void IncreaseHealth()
    {
        if (levelPoints >= 1)
        {
            player.GetComponent<PlayerController>().maxHealth+=50;
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
}

