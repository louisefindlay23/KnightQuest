using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
	public Dropdown dd;
	
	public void valueChanged() {
		switch (dd.value) {
			case 1:
                
				SceneManager.LoadScene ("Village");
			break;
			case 2:
				SceneManager.LoadScene ("Mountain");
			break;
		}
	}
}
