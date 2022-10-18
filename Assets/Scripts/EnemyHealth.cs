using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 30;
    
    public AudioClip Death;
    AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Start Enemy Death Animation if an Enemy runs out of health
        if (curHealth < 1) {
            gameObject.GetComponent<Animator>().SetBool("Dead", true);
            Debug.Log("Enemy Dead");
            StartCoroutine (KillEnemy ());
}
            // When Death animation finishes, destroy Enemy
             IEnumerator KillEnemy()
         {
             while (true) {
                 yield return new WaitForSeconds(3.0f);
                 if (PlayerPrefs.GetString("SFX") == "enabled") {
                    audioPlayer.PlayOneShot(Death, 0.7F);
                 }
                 Destroy(this.gameObject);
             }
        }
    }

    public void DamageEnemy( int damage )
    {
        if (damage > curHealth) {
            GameObject.Find("Main Camera").GetComponent<CameraController>().UpdateKills();
        }
        curHealth -= damage;
    }
}