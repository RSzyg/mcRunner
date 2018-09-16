using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		GameObject obj = other.collider.gameObject;
		if (obj.GetComponent<PlayerController>()) {
			obj.GetComponent<PlayerController>().StopJumping();
		}
	}
}
