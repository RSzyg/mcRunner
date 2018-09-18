using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public bool isAlive;
	public float energy;
	public Rigidbody2D rb;
	private bool jumping;

	// Use this for initialization
	void Start () {
		isAlive = true;
		energy = 60.0f;
		jumping = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive && !jumping && Input.GetMouseButtonDown(0)) {
			jumping = true;
			rb.velocity = new Vector2(rb.velocity.x, 12.0f);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Floor") {
			StopJumping();
		}

		if (other.gameObject.tag == "PrimaryObstacle") {
			Debug.Log("dead");
			isAlive = false;
		}
	}

	public void StopJumping() {
		jumping = false;
	}

	public void EnergyController(int val) {
		energy += val;
		DeadthJudge();
	}

	public void DeadthJudge() {
		if (energy <= 0) {
			Debug.Log("dead");
			isAlive = false;
		}
	}
}
