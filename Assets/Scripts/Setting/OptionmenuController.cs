using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionmenuController : MonoBehaviour {
    public Button OnButton;
    public Button OffButton;
    public bool isPlaying;

    private void Start()
    {
        isPlaying = true;
        PlayerPrefs.SetInt("mute", isPlaying ? 1 : 0);
        OnButton.onClick.AddListener(Turnon);
        OffButton.onClick.AddListener(Turnoff);
        OnButton.GetComponent<Image>().color = Color.yellow;
    }
    
    private void Turnon()
    {
        isPlaying = true;
        PlayerPrefs.SetInt("mute", isPlaying ? 1 : 0);
        OnButton.GetComponent<Image>().color = Color.yellow;
        OffButton.GetComponent<Image>().color = Color.white;
    }

    private void Turnoff()
    {
        isPlaying = false;
        PlayerPrefs.SetInt("mute", isPlaying ? 1 : 0);
        OffButton.GetComponent<Image>().color = Color.yellow;
        OnButton.GetComponent<Image>().color = Color.white;
    }
}
