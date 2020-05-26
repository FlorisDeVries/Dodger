using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to help swap to other menu's
/// </summary>
public class MainMenu : MonoBehaviour {
	public Canvas mainMenu, help, settings;

	void Start() {
		Menu();
	}

	public void Settings(){
		DisableAll();
		settings.enabled = true;
	}

	public void Help(){
		DisableAll();
		help.enabled = true;
	}

	public void Menu(){
		DisableAll();
		mainMenu.enabled = true;
	}

	public void DisableAll(){
		mainMenu.enabled = false;
		help.enabled = false;
		settings.enabled = false;
	}
}
