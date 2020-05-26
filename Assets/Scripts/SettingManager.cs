using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Manager for setting/getting settings
/// </summary>
public class SettingManager : MonoBehaviour {

	public AudioMixer mixer;
	public Slider master, music, sound;
	
	void Start() {
		master.value = PlayerPrefs.GetFloat("MasterVolume", -10);
		music.value = PlayerPrefs.GetFloat("MusicVolume", -10);
		sound.value = PlayerPrefs.GetFloat("SoundVolume", -10);
	}

	// Only this one is used for now(only one audio track)
	public void SetMaster(float volume){
		mixer.SetFloat("MasterVolume", volume);
		PlayerPrefs.SetFloat("MasterVolume", volume);
	}

	public void SetMusic(float volume){
		mixer.SetFloat("MusicVolume", volume);
		PlayerPrefs.SetFloat("MusicVolume", volume);
	}

	public void SetSound(float volume){
		mixer.SetFloat("SoundVolume", volume);
		PlayerPrefs.SetFloat("SoundVolume", volume);
	}

}
