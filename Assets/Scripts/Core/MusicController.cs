using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    public AudioSource music;

    private bool mute;
    private float musicVolume;
    // Use this for initialization
    void Start () {
        mute = PlayerPrefs.GetInt("mute") == 1 ? true : false;
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        Debug.Log(PlayerPrefs.GetInt("mute"));
        if (mute)
        {
            Debug.Log("fuck");
            music.Play();
            music.volume = musicVolume * 100;
        }
        else
        {
            music.Stop();
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
