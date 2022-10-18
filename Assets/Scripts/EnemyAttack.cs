using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject hero;
    AudioSource audioPlayer;
    public AudioClip HeroHurtSnd;
    
     // Use this for initialization
     void Start () {
     hero = GameObject.Find("RPGHeroHP");
     audioPlayer = GetComponent<AudioSource>();
     }
     
     // Update is called once per frame
     void Update () {
     
     }
     
     // Damage Player on Collision with Enemy
     void  OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player") {
            hero.GetComponent<Animator>().SetBool("Hurt", true);
            if (PlayerPrefs.GetString("SFX") == "enabled") {
                col.gameObject.GetComponent<AudioSource>().PlayOneShot(HeroHurtSnd, 0.7F);
            }
            Debug.Log("Hero Damaged");
            hero.GetComponent<HeroHealth>().DamagePlayer(10);
            hero.GetComponent<Animator>().SetBool("Hurt", false);
		}
	}
}
