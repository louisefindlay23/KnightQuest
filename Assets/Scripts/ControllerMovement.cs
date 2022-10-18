using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ControllerMovement : MonoBehaviour
{

    GameObject cameraObj;
    AudioSource audioPlayer;
    Animator hero_Animator;
    
    public GameObject enemy;
    public float spawnTime = 1f;
    private Vector3 spawnPosition;
    public float maxspeed = 5;

    public AudioClip MenuMove;
    EventSystem evt;
    
    GameObject StartBtn;
    GameObject Dropdown;
    GameObject MusicSettings;
    GameObject SFXSettings;
    GameObject Quit;
    
    int speed;
    Vector2 movementValue;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
        hero_Animator = gameObject.GetComponent<Animator>();
        audioPlayer = gameObject.GetComponent<AudioSource>();
        evt = EventSystem.current;
        
        StartBtn = GameObject.Find("StartBtn");
        Dropdown = GameObject.Find("Dropdown");
        MusicSettings = GameObject.Find("MusicSettings");
        SFXSettings = GameObject.Find("SFXSettings");
        Quit = GameObject.Find("Quit");
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    // Move Player using Left Stick   
    public void OnMove(InputAction.CallbackContext context)
    {
        speed = 10;
        movementValue = context.ReadValue<Vector2>();
        
        if (!hero_Animator.GetBool("Die")) {
        transform.position += new Vector3(movementValue.x * speed * Time.deltaTime,
                                        0,
                                        movementValue.y * speed * Time.deltaTime);
        }
    }
    
    // Navigate UI Menus using Controller
    public void OnNavigate()
    {
        if (PlayerPrefs.GetString("SFX") == "enabled") {
            audioPlayer.PlayOneShot(MenuMove, 1.0F);
        }
    }
    
    // Jump by Pressing B
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!hero_Animator.GetBool("Die")) {
        
            transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
            Debug.Log("Jumped");
        }
    }
    
    // Attack by Pressing X
   public void OnAttack(InputAction.CallbackContext context)
   {     
        if (!hero_Animator.GetBool("Die")) {
        
            if (context.started) {
            hero_Animator.SetBool("Attack", true);
                 if (PlayerPrefs.GetString("SFX") == "enabled") {
                    audioPlayer.Play();
                }
            } else if (context.canceled) {
                hero_Animator.SetBool("Attack", false);
                hero_Animator.SetBool("AttackEnded", true);
                audioPlayer.Stop();
            }
        }
    }
    
    // Spawn Enemies by Holding Y
    public void OnSpawnEnemy(InputAction.CallbackContext context)
    {  
    
        if (!hero_Animator.GetBool("Die")) {
            if (context.started) {
                InvokeRepeating ("CloseSpawn", spawnTime, spawnTime);
            } else if (context.canceled) {
                CancelInvoke();
            }
        }
    }
    
    void CloseSpawn() {
        
        Vector3 pos = transform.position; // gets current location
        Instantiate(enemy, pos, Quaternion.identity);
    }
}
