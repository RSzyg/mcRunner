using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public bool isAlive;
	public static float energy;
	public Rigidbody2D rb;
	public bool jumping;

	// Use this for initialization
	void Start () {
		isAlive = true;
		energy = 60.0f;
		jumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        DeadthJudge();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Floor") {
			StopJumping();
		}

		if (other.gameObject.tag == "RoadFence") {
			isAlive = false;
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Food")
        {
            EnergyController(other.gameObject.GetComponent<FoodBasicAttr>().energy);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BreakableObstacle")
        {
            GetComponent<AudioSource>().Play();
            EnergyController(-10.0f);
			Destroy(other.GetComponent<Collider2D> ());
			other.transform.Translate(Vector3.right * other.transform.localScale.y / 2);
			other.transform.Rotate(Vector3.back * 90);
        }
    }

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "ManholeCover") {
			rb.isKinematic = true;
			rb.velocity = new Vector2(2, -5);
			isAlive = false;
		}
	}

    public void StopJumping() {
		jumping = false;
		GetComponent<Animator> ().Play("Running");
	}

	public void EnergyController(float val) {
		energy += val;
	}

	public void DeadthJudge() {
		if (energy <= 0 || energy > 100) {
			Debug.Log("dead");
			isAlive = false;
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
