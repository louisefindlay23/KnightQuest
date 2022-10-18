using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private int deathIncrease;
    
    // Start is called before the first frame update
    void Start()
    {
        deathIncrease = PlayerPrefs.GetInt("deaths");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onClick() {
        // Increase deaths if Player chooses to Quit game
        deathIncrease += 1;
        PlayerPrefs.SetInt("deaths", deathIncrease);
        PlayerPrefs.Save();
        Application.Quit();
	}
    
}
