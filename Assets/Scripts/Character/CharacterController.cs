using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	public bool jumping;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		jumping = true;
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
}
