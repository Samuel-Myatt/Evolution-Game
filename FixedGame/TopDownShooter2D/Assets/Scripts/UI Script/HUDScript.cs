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

    public GameObject Hud;
    public GameObject skillTreeUI;

    //Grab player GameObject and Script
    public Text PlayerHealth;
    float PlayerHP;

    //Grab egg GameObject and Script
    public Text EggHealth;
    float EggHP;

    public Text levelPoints;
    public int points;

    //Grab round GameObject and Script



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

    }

    // Update is called once per frame
    void Update()
    {
        FetchValues();
        
    }


    void FetchValues()
    {
        //Get PlayerHP
        PlayerHP = Player.GetComponent<PlayerController>().health;
        PlayerHealth.text = ("Health  ") + PlayerHP.ToString();


        //Get EGGHP
        EggHP = Egg.GetComponent<EggController>().health;
        EggHealth.text = ("HP  ") + EggHP.ToString();

        //Get Round no.
        //RoundNumb = RoundNum;
        
        RoundNumb = GameHandler.GetComponent<WaveSpawner>().round;
        
        RoundNumber.text = ("Round:  ") + RoundNumb.ToString();


        levelPoints.text = ("DNA Points:  ") + skillTreeUI.GetComponent<SkillTreeUI>().levelPoints.ToString();


    }

}
