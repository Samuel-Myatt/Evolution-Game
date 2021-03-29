using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip PlayerShoot, DeathSound, SoldierShoot, TankShoot, DrillSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShoot = Resources.Load<AudioClip>("Shooting noise 2");
        DeathSound = Resources.Load<AudioClip>("Enemy Death");
        SoldierShoot = Resources.Load<AudioClip>("Gun Sound");
        TankShoot = Resources.Load<AudioClip>("Tank Shoot");
        DrillSound = Resources.Load<AudioClip>("Drill Sound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
	{
		switch (clip)
        {
            case "PlayerShoot":
            audioSrc.PlayOneShot(PlayerShoot);
            break;
        case "DeathSound":
            audioSrc.PlayOneShot(DeathSound);
            break;
        case "SoldierShoot":
            audioSrc.PlayOneShot(SoldierShoot);
            break;
        case "TankShoot":
            audioSrc.PlayOneShot(TankShoot);
            break;
        case "DrillSound":
            audioSrc.PlayOneShot(DrillSound);
            break;
        }
	}
}
