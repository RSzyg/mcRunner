using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

	public void LoadSceneById(int id) {
		SceneManager.LoadScene(id, LoadSceneMode.Single);
	}
}
