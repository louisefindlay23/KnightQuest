using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReviveHero : MonoBehaviour
{
    GameObject hero;
    private Canvas GameOverCanvas;
    
    private Text DeathText;
    private int deathIncrease;
    
    void Awake()
{
    if (!PlayerPrefs.HasKey("deaths"))
    //Load the saved score (this value will be saved even if you restart the app)
    PlayerPrefs.SetInt("deaths", 0);
    PlayerPrefs.Save();
}
    
    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        DeathText = GameObject.Find("DeathCanvas").GetComponentInChildren<Text>();
        DeathText.text = PlayerPrefs.GetInt("deaths").ToString();
        deathIncrease = PlayerPrefs.GetInt("deaths");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onClick() {
        // On Game Over, when Player chooses Revive (increase deaths and reload Scene)
        deathIncrease += 1;
        PlayerPrefs.SetInt("deaths", deathIncrease);
        PlayerPrefs.Save();
        DeathText.text = PlayerPrefs.GetInt("deaths").ToString();
        SceneManager.LoadScene("Village");
	}
    
}
