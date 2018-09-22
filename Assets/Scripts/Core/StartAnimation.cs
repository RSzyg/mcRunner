using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnimation : MonoBehaviour {
	private int TimeCount;

	void Awake() {
		TimeCount = 0;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (++TimeCount >= 120) {
			SceneManager.LoadScene(1);
		}
	}
}
