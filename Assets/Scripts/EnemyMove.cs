using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{

    Transform Player;
    private GameObject hero;
    int MoveSpeed = 5;
    int MaxDist = 10;
    int MinDist = 1;
    
    Animator hero_Animator;
    Animator enemy_Animator;
    
    public AudioClip swordsSound;
    AudioSource audioSource;
    private AudioSource backgroundMusic;
    private AudioSource[] allAudioSources;
    
    bool battle;
    
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("RPGHeroHP");
        Player = hero.GetComponent<Transform>();
        
        hero_Animator = hero.GetComponent<Animator>();
        enemy_Animator = gameObject.GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hero_Animator.GetBool("Die")) {
        
        // Enemy Targets Player
        transform.LookAt(Player);
 
         if (Vector3.Distance(transform.position, Player.position) >= MinDist)
         {
 
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            enemy_Animator.SetBool("Attack", false);
 
            // Enemy Goes Into Attack Mode
             if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
             {
                enemy_Animator.SetBool("Attack", true);
                battle = true;
                GameObject.Find("Main Camera").GetComponent<CameraController>().PlayBattleMusic(battle);
                
        // } else if (!enemy_Animator.GetBool("Attack")) {
           // audio.clip = VillageMusic;
            //audio.Play();
      //  }
                //audioSource.PlayOneShot(swordsSound, 0.7F);
             } else {
                enemy_Animator.SetBool("Attack", false);
                enemy_Animator.SetBool("AttackEnded", true);
             }
 
         }
        }
    }
    
    // Push back enemies if they collide
    void OnCollisionEnter(Collision col)
 {
     // force is how forcefully we will push the player away from the enemy.
     float force = 300;
 
     // If the object we hit is the enemy
     if (col.gameObject.tag == "Enemy")
     {
         // Calculate Angle Between the collision point and the player
         Vector3 dir = col.contacts[0].point - transform.position;
         // We then get the opposite (-Vector3) and normalize it
         dir = -dir.normalized;
         // And finally we add force in the direction of dir and multiply it by force. 
         // This will push back the player
         GetComponent<Rigidbody>().AddForce(dir*force);
         Debug.Log("Enemies collided");
     }
 }
}
