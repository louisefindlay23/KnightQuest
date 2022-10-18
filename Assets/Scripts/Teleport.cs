using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    
    GameObject hero;
    GameObject portal;
    
    public Transform Player;
    int MaxDist = 10;
    
    AudioSource audioPlayer;
    public AudioClip teleporting;

    // Use this for initialization
     void Start () {
         hero = GameObject.Find ("RPGHeroHP");
         Player = hero.GetComponent<Transform>();
         portal = GameObject.Find ("TeleportDestination");
         
         audioPlayer = GetComponent<AudioSource>();
     }
    
    void Update () {
        
        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
         {
            if (PlayerPrefs.GetString("music") == "enabled") {
                Debug.Log("Teleport Music");
                audioPlayer.Play();
            }
        }
    }
    
    void  OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player") {
            if (PlayerPrefs.GetString("SFX") == "enabled") {
                audioPlayer.PlayOneShot(teleporting, 0.7F);
            }
            hero.transform.position = portal.transform.position;
		}
	}
}

