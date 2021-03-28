using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    //GameObjects
    GameObject Player;

    GameObject Egg;

    GameObject GameHandler;

    //Grab player GameObject and Script
    public Text PlayerHealth;
    float PlayerHP;
 
    //Grab egg GameObject and Script
    public Text EggHealth;
    float EggHP;

    //Grab round GameObject and Script
  
    
    //From countdown script


    public Text RoundNumber;
    int RoundNumb;
    //wave spawner script roundNum


    // Start is called before the first frame update
    void Start()
    {
        //Grabbing Game Objects
        //PlayerHP
        Player = GameObject.Find("Player");
        //EggHP
        Egg = GameObject.Find("Egg");
        //RoundNo.
        GameHandler = GameObject.Find("GameManager");

        //Enables HUD on start incase diabled
        EnableHUD();
    }

    // Update is called once per frame
    void Update()
    {
        FetchValues();
    }

    public static void EnableHUD()
    {
        GameObject.Find("HUD").SetActive(true);
    }

    public static void DisableHUD()
    {
        GameObject.Find("HUD").SetActive(false);
    }

    void FetchValues()
    {
        //Get PlayerHP
        PlayerHP = Player.GetComponent<PlayerController>().health;
        PlayerHealth.text = PlayerHP.ToString();

        //Get EGGHP
        EggHP = Egg.GetComponent<EggController>().health;
        EggHealth.text = EggHP.ToString();

        //Get Round no.
        //RoundNumb = RoundNum;
        /*
        RoundNumb = GameHandler.GetComponent<WaveSpawner>().roundNum;
        */
        RoundNumber.text = RoundNumb.ToString();

        //Get Timer
        
    }

}
