using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public HealthBar healthBar;
    Animator hero_Animator;
    Animator enemyAnimator;
    Canvas GameOverCanvas;
    
    public AudioClip Death;
    AudioSource audioPlayer;
    
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        hero_Animator = gameObject.GetComponent<Animator>();
        
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        GameOverCanvas.enabled = false;
        
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
            // Start Dead Hero Animation if Player Dies
            if (curHealth < 1) {
            hero_Animator.SetBool("Attack", false);
            hero_Animator.SetBool("AttackEnded", true);
            hero_Animator.SetBool("Die", true);
            Debug.Log("Hero Dead");
            audioPlayer.Stop();
            StartCoroutine (KillHero ());
        }
    
    }
            // Wait for Death Animation to finish before showing Game Over Screen
             IEnumerator KillHero()
         {
             while (true) {
                 Debug.Log ("Start Hero Death");
                 yield return new WaitForSeconds(2.0f);
                 if (PlayerPrefs.GetString("SFX") == "enabled") {
                    audioPlayer.PlayOneShot(Death, 0.7F);
                 }
                 GameOverCanvas.enabled = true;
                 
                 enemies = GameObject.FindGameObjectsWithTag("Enemy");
                 
                 foreach (GameObject enemy in enemies) {
                    enemyAnimator = enemy.GetComponent<Animator>();
                    enemyAnimator.SetBool("Attack", false);
                    enemyAnimator.SetBool("AttackEnded", true);
                    enemyAnimator.SetBool("Hurt", false);
                    enemyAnimator.SetBool("HeroDead", true);
                    Debug.Log(enemyAnimator.GetBool("HeroDead"));
                }
                 break;
             }
        }
        
    // Damage and Heal Player
    public void DamagePlayer( int damage )
    {
        curHealth -= damage;

        healthBar.SetHealth( curHealth );
    }
    
    public void HealPlayer( int healing )
    {
        curHealth += healing;

        healthBar.SetHealth( curHealth );
    }
    
}