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

    public int unlockDashRequired;
    public int increaseHealthRequired;
    public int increaseSpeedRequired;
    public int increaseDashSizeRequired;
    public int healRequired;
    public int unlockReflectorRequired;
    public int unlockChargedShotRequired;
    public int unlockDOTRequired;



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
        if (levelPoints >= unlockDashRequired)
        {
            player.GetComponent<PlayerController>().dashUnlocked = true;
            levelPoints -= unlockDashRequired;
            Debug.Log("TheClick");
        }
    }
    public void IncreaseHealth()
    {

        if (levelPoints >= increaseHealthRequired)
        {
            player.GetComponent<PlayerController>().maxHealth += 50;
            levelPoints -= increaseHealthRequired;

        }
    }
    public void IncreaseSpeed()
    {

        if (levelPoints >= increaseSpeedRequired)
        {
            player.GetComponent<PlayerController>().speed += 2;
            levelPoints -= increaseSpeedRequired;

        }
    }
    public void IncreaseDashSize()
    {

        if (levelPoints >= increaseDashSizeRequired)
        {
            //player.GetComponent<PlayerController>().dashDistance += 20;
            player.GetComponent<PlayerController>().dashSpeed += 20;
            levelPoints -= increaseDashSizeRequired;

        }
    }
    public void Heal()
    {

        if (levelPoints >= healRequired)
        {
            player.GetComponent<PlayerController>().health += 25;
            levelPoints -= healRequired;

        }
    }
    public void UnlockReflector()
    {
        Debug.Log("Clicked");
        if (levelPoints >= unlockReflectorRequired)
        {
            player.GetComponent<PlayerController>().reflectorUnlocked = true;
            levelPoints -= unlockReflectorRequired;
            Debug.Log("TheClick");
        }
    }
    public void UnlockChargedShot()
    {
        Debug.Log("Clicked");
        if (levelPoints >= unlockChargedShotRequired)
        {
            player.GetComponent<FireWeapon>().chargedBulletUnlocked = true;
            levelPoints -= unlockChargedShotRequired;
            Debug.Log("TheClick");
        }
    }
    public void UnlockDOTShot()
    {
        Debug.Log("Clicked");
        if (levelPoints >= unlockDOTRequired)
        {
            player.GetComponent<FireWeapon>().DOTBulletUnlocked = true;
            levelPoints -= unlockDOTRequired;
            Debug.Log("TheClick");
        }
    }

}