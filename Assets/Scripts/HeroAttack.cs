using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    Animator hero_Animator;
    GameObject enemy;
    
    AudioSource audioPlayer;
    public AudioClip EnemyHurt;
    
    int HeroStrength;
    
     // Use this for initialization
     void Start () {
     hero_Animator = gameObject.GetComponent<Animator>();
     enemy = GameObject.Find("footman_Blue_HP");
     audioPlayer = gameObject.GetComponent<AudioSource>();
     // Determine Hero's strength based on player deaths
     HeroStrength = PlayerPrefs.GetInt("deaths") + 10;
     }
     
     // Update is called once per frame
     void Update () {
     
        // Hero Attacks on Space Bar
        if (!hero_Animator.GetBool("Die")) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                 hero_Animator.SetBool("Attack", true);
                 if (PlayerPrefs.GetString("SFX") == "enabled") {
                    audioPlayer.Play();
                }
             }
             else if(Input.GetKeyUp(KeyCode.Space)) {
                hero_Animator.SetBool("Attack", false);
                hero_Animator.SetBool("AttackEnded", true);
                audioPlayer.Stop();
             }
         }
     }
     
    // Damage Enemies (using Hero STR stat) on Collision
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == "Enemy") {
            Debug.Log("Enemy Damaged");
            if (PlayerPrefs.GetString("SFX") == "enabled") {
                audioPlayer.PlayOneShot(EnemyHurt, 0.7F);
            }
            col.gameObject.GetComponent<Animator>().SetBool("Hurt", true);
            col.gameObject.GetComponent<EnemyHealth>().DamageEnemy(HeroStrength);
        }
    
    }
}
