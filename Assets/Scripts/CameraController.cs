using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraDistance = 10.0f;
    GameObject enemy;
    
    public float spawnTime = 1f;
    private Vector3 spawnPosition;
    public float maxspeed = 5;
    
    Animator enemy_Animator;
    Animator hero_Animator;
    
    public AudioClip BattleMusic;
    AudioSource audioPlayer;
    bool battle;
    
    private Text KillsText;
    private int Kills;
    
    // Frame Rate Lock when Editing
     void Awake () {
     #if UNITY_EDITOR
     QualitySettings.vSyncCount = 0;  // VSync must be disabled
     Application.targetFrameRate = 60;
     #endif
 }

    // Use this for initialization
    void Start () {
        enemy = GameObject.Find("footman_Blue_HP");
        enemy_Animator = enemy.GetComponent<Animator>();
        hero_Animator = GameObject.Find("RPGHeroHP").GetComponent<Animator>();
        
        KillsText = GameObject.Find("KillsCanvas").GetComponentInChildren<Text>();
        KillsText.text = Kills.ToString();
        Kills = 0;
        
        // Play Background Music if allowed
        audioPlayer = GetComponent<AudioSource>();
        
        if (PlayerPrefs.GetString("music") == "enabled") {
                audioPlayer.Play();            
     }
    }
    
    void Update () {
        
        // Enemy Spawn
        if (Input.GetKeyDown(KeyCode.E)) {
            InvokeRepeating ("CloseSpawn", spawnTime, spawnTime);
        } else if (Input.GetKeyUp(KeyCode.E)) {
            CancelInvoke ();
        }
    }
    
    // Spawn Enemies
    void CloseSpawn() {
        
        Vector3 pos = transform.position; // gets current location
        Instantiate(enemy, pos, Quaternion.identity);
    }
    
    public void PlayBattleMusic(bool battle) {
        if (battle == true) {
            if (PlayerPrefs.GetString("music") == "enabled") {
                    audioPlayer.Stop();
                    audioPlayer.clip = BattleMusic;
                    if (!audioPlayer.isPlaying) {
                        audioPlayer.Play();
                        Debug.Log("Battle Music");
                    }
                } else if (hero_Animator.GetBool("Die")) {
                    audioPlayer.Stop();
                }
        }
    }
    
    public void UpdateKills() {
        Kills += 1;
        KillsText.text = Kills.ToString();
    }
    
    // Move Camera Near Player
    void LateUpdate ()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.LookAt (player.transform.position);
        transform.position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);
    }
}