using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionmenuController : MonoBehaviour {
    public Button OnButton;
    public Button OffButton;
    public static bool isPlaying = true;

    private void Start()
    {
        if (isPlaying)
        {
            OnButton.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            OffButton.GetComponent<Image>().color = Color.yellow;
        }
        OnButton.onClick.AddListener(Turnon);
        OffButton.onClick.AddListener(Turnoff);
    }
    
    private void Turnon()
    {
        isPlaying = true;
        OnButton.GetComponent<Image>().color = Color.yellow;
        OffButton.GetComponent<Image>().color = Color.white;
    }

    private void Turnoff()
    {
        isPlaying = false;
        OffButton.GetComponent<Image>().color = Color.yellow;
        OnButton.GetComponent<Image>().color = Color.white;
    }
}
