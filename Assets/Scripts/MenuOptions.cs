using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuOptions : MonoBehaviour
{
    AudioSource audioPlayer;
    public AudioClip MenuMove;
    public AudioClip MenuConfirm;
    
    Text MusicState;
    Text SFXState;
    public List<AudioSource> audioSources;
    
    GameObject StartButton;
    
    void Awake()
    {
        // Set SFX and Music PlayerPrefs if they don't already exist
        if (!PlayerPrefs.HasKey("music"))
        PlayerPrefs.SetString("music", "enabled");
        PlayerPrefs.Save();
    
        if (!PlayerPrefs.HasKey("SFX"))
        PlayerPrefs.SetString("SFX", "enabled");
        PlayerPrefs.Save();
    }
    
    // Start is called before the first frame update
    void Start()
    {       
        audioPlayer = gameObject.GetComponent<AudioSource>();
        MusicState = GameObject.Find("MusicSettings").GetComponentInChildren<Text>();
        SFXState = GameObject.Find("SFXSettings").GetComponentInChildren<Text>();
        
        StartButton = GameObject.Find("StartBtn");
        
        // Set SFX and Music Button Text to Off if it has previously
        if (PlayerPrefs.GetString("music") == "muted") {
            MusicState.text = "Music Off";
        }
        MusicCheck();
        
        if (PlayerPrefs.GetString("SFX") == "muted") {
            SFXState.text = "SFX Off";
        }
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

    
    public void StartGame() {
        SceneManager.LoadScene("Village");
	}
    
    public void QuitGame() {
        Application.Quit();
    }
    
    public void ViewInstructions() {
        SceneManager.LoadScene("Instructions");
    }
    
    public void MusicControl() {
        
       if (PlayerPrefs.GetString("music") == "enabled") {
            MusicState.text = "Music Off";
            PlayerPrefs.SetString("music", "muted");
            PlayerPrefs.Save();
        } else if (PlayerPrefs.GetString("music") == "muted") {
            MusicState.text = "Music On";
            PlayerPrefs.SetString("music", "enabled");
            PlayerPrefs.Save();
        }
        
        MusicCheck();
    }
    
    public void SFXControl() {
        
       if (PlayerPrefs.GetString("SFX") == "enabled") {
            SFXState.text = "SFX Off";
            PlayerPrefs.SetString("SFX", "muted");
            PlayerPrefs.Save();
        } else if (PlayerPrefs.GetString("SFX") == "muted") {
            SFXState.text = "SFX On";
            PlayerPrefs.SetString("SFX", "enabled");
            PlayerPrefs.Save();
        }
        
        Debug.Log(PlayerPrefs.GetString("SFX"));
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
