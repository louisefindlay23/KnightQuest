using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsNav : MonoBehaviour
{
    AudioSource audioPlayer;
    public AudioClip MenuMove;
    public AudioClip MenuConfirm;
    
    GameObject BackButton;
    
    public List<AudioSource> audioSources;
    
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
        BackButton = GameObject.Find("Back");
        
        MusicCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MenuMoveSFX() {
    Debug.Log(PlayerPrefs.GetString("SFX"));
        if (PlayerPrefs.GetString("SFX") == "enabled") {
            audioPlayer.PlayOneShot(MenuMove, 1.0F);
        }
    }
    
    public void MenuConfirmSFX() {
        if (PlayerPrefs.GetString("SFX") == "enabled") {
        audioPlayer.PlayOneShot(MenuConfirm, 1.0F);
        }
    }
    
    public void CloseInstructions() {
        SceneManager.LoadScene("Menu");
    }
    
    public void MusicCheck()
    {   
        if (PlayerPrefs.GetString("music") == "enabled") {
            foreach(AudioSource musicAudio in audioSources) {
                musicAudio.Play();
            }
     } else if (PlayerPrefs.GetString("music") == "muted") {
          foreach(AudioSource musicAudio in audioSources) {
            musicAudio.Stop();
            }
        }

    }
}
