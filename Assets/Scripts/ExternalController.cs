using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExternalController : MonoBehaviour {
	
	public GameObject PauseUI;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			switch (SceneManager.GetActiveScene().name)
			{
				case "Menu":
					Application.Quit();
					break;
				default:
					break;
			}
		}
	}
}
