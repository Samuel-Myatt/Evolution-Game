using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUI : MonoBehaviour
{
    public static bool paused = false;
    public GameObject skills;
    public GameObject player;
    public GameObject egg;
    public int levelPoints;
    public GameObject hud;
    public GameObject buttonSpawns;


    public int unlockDashRequired;
    public int increaseHealthRequired;
    public int increaseSpeedRequired;
    public int increaseDashSizeRequired;
    public int healRequired;
    public int unlockReflectorRequired;
    public int unlockChargedShotRequired;
    public int unlockDOTRequired;
    public int unlockMultiShotRequired;
    public int healEggRequired;

    public int increaseDashAmount;
    public int increaseHealthAmount;
    public int increaseSpeedAmount;
    public int healAmount;
    public int healEggAmount;

    public Text unlockDashCost;
    public Text increaseHealthCost;
    public Text increaseSpeedCost;
    public Text increaseDashCost;
    public Text healCost;
    public Text unlockReflectorCost;
    public Text unlockChargedCost;
    public Text unlockDOTCost;
    public Text unlockMultiShotCost;
    public Text healEggCost;

    public Text maxHealth;

    public GameObject unlockedDash;
    public GameObject maxSpeed;
    public GameObject maxDashSpeed;
    public GameObject shieldUnlocked;
    public GameObject chargedShotUnlocked;
    public GameObject DOTunlocked;
    public GameObject multiShotUnlocked;





    private void Start()
    {
        player.GetComponent<PlayerController>();
    }
    void Update()
    {
        unlockDashCost.text = ("Unlock Dash Cost ") + unlockDashRequired.ToString();
        increaseHealthCost.text = ("Increase Max Health Cost ") + increaseHealthRequired.ToString();
        increaseSpeedCost.text = ("Increase Speed Cost ") + increaseSpeedRequired.ToString();
        increaseDashCost.text = ("Increase Dash Cost ") + increaseDashSizeRequired.ToString();
        healCost.text = ("Heal player Cost ") + healRequired.ToString();
        unlockReflectorCost.text = ("Unlock Shield Cost ") + unlockReflectorRequired.ToString();
        unlockChargedCost.text = ("Unlock Charged Shot Cost ") + unlockChargedShotRequired.ToString();
        unlockDOTCost.text = ("Unlock Damage over time bullet Cost ") + unlockDOTRequired.ToString();
        unlockMultiShotCost.text = ("Unlock Multi Shot Cost ") + unlockMultiShotRequired.ToString();
        healEggCost.text = ("Heal egg Cost ") + healEggRequired.ToString();

        maxHealth.text = " Current Health " + player.GetComponent<PlayerController>().health.ToString() + "    Max Health " + player.GetComponent<PlayerController>().maxHealth.ToString();

        if(player.GetComponent<PlayerController>().speed == player.GetComponent<PlayerController>().maxSpeed)
        {
            maxSpeed.SetActive(true);
        }
        if (player.GetComponent<PlayerController>().dashSpeed == player.GetComponent<PlayerController>().maxDashSpeed)
        {
            maxDashSpeed.SetActive(true);
        }

    }
    public void Resume()
    {
        skills.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        buttonSpawns.GetComponent<SpawnButton>().DestroyButtons();
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
        if (levelPoints >= unlockDashRequired&& player.GetComponent<PlayerController>().dashUnlocked == false)
        {
            unlockedDash.SetActive(true);
            player.GetComponent<PlayerController>().dashUnlocked = true;
            
            levelPoints -= unlockDashRequired;
            
            Debug.Log("TheClick");
        }
    }
    public void IncreaseHealth()
    {

        if (levelPoints >= increaseHealthRequired && player.GetComponent<PlayerController>().health < player.GetComponent<PlayerController>().maxHealth)
        {
            player.GetComponent<PlayerController>().maxHealth += increaseHealthAmount;
            
            levelPoints -= increaseHealthRequired;

        }
    }
    public void IncreaseSpeed()
    {

        if (levelPoints >= increaseSpeedRequired && player.GetComponent<PlayerController>().speed < player.GetComponent<PlayerController>().maxSpeed)
        {
            player.GetComponent<PlayerController>().speed += increaseSpeedAmount;
            
            levelPoints -= increaseSpeedRequired;

        }
    }
    public void IncreaseDashSize()
    {

        if (levelPoints >= increaseDashSizeRequired && player.GetComponent<PlayerController>().dashUnlocked == true)
        {
            //player.GetComponent<PlayerController>().dashDistance += 20;
            player.GetComponent<PlayerController>().dashSpeed += increaseDashAmount;
            
            levelPoints -= increaseDashSizeRequired;

        }
    }
    public void Heal()
    {

        if (levelPoints >= healRequired && player.GetComponent<PlayerController>().health < player.GetComponent<PlayerController>().maxHealth)
        {
            player.GetComponent<PlayerController>().health += healAmount;
            
            levelPoints -= healRequired;

        }
    }
    public void UnlockReflector()
    {
        Debug.Log("Clicked");
        if (levelPoints >= unlockReflectorRequired && player.GetComponent<PlayerController>().reflectorUnlocked == false)
        {
            player.GetComponent<PlayerController>().reflectorUnlocked = true;
            shieldUnlocked.SetActive(true);
            levelPoints -= unlockReflectorRequired;
            Debug.Log("TheClick");
        }
    }
    public void UnlockChargedShot()
    {
        Debug.Log("Clicked");
        if (levelPoints >= unlockChargedShotRequired && player.GetComponent<FireWeapon>().chargedBulletUnlocked == false)
        {
            player.GetComponent<FireWeapon>().chargedBulletUnlocked = true;
            chargedShotUnlocked.SetActive(true);
           
            levelPoints -= unlockChargedShotRequired;
            Debug.Log("TheClick");
        }
    }
    public void UnlockDOTShot()
    {
        Debug.Log("Clicked");
        if (levelPoints >= unlockDOTRequired && player.GetComponent<FireWeapon>().DOTBulletUnlocked == false)
        {
            player.GetComponent<FireWeapon>().DOTBulletUnlocked = true;
            DOTunlocked.SetActive(true);
            levelPoints -= unlockDOTRequired;
            Debug.Log("TheClick");
        }
    }
    public void UnlockMultiShot()
    {

        if (levelPoints >= unlockMultiShotRequired && player.GetComponent<FireWeapon>().multiBulletUnlocked == false)
        {
            player.GetComponent<FireWeapon>().multiBulletUnlocked = true;
            multiShotUnlocked.SetActive(true);
            levelPoints -= unlockMultiShotRequired;

        }
    }
    public void HealEgg()
    {
        if (levelPoints >= healEggRequired)
        {
            egg.GetComponent<EggController>().health += healEggAmount;

            levelPoints -= healEggRequired;

        }
    }

}
