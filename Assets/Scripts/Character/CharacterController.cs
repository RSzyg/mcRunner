using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
	public float energy;
	public bool jumping;
	public Text energyDisplay;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		energy = 60.0f;
		jumping = true;
		energyDisplay.text = "Energy: " + energy;
	}
	
	// Update is called once per frame
	void Update () {
		if (!jumping && Input.GetMouseButtonDown(0)) {
			jumping = true;
			rb.velocity = new Vector2(rb.velocity.x, 10.0f);
		}
	}

	public void StopJumping() {
		jumping = false;
	}

	public void EnergyController(int val) {
		energy += val;
		energyDisplay.text = "Energy: " + energy;
		DeadthJudge();
	}

	public void DeadthJudge() {
		if (energy <= 0) {
			Debug.Log("dead");
		}
	}
}
