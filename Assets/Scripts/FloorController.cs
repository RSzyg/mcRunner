using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
	
	public GameObject[] Obstacle;
	public GameObject[] Food;

	// Use this for initialization
	void Start () {
		int type = Random.Range(0, 2);
		int rndNum = 0;
		GameObject tamplate = Obstacle[0];
		switch (type)
		{
			case 0:
				rndNum = Random.Range(0, Obstacle.Length);
				tamplate = Obstacle[rndNum];
				break;
			case 1:
				rndNum = Random.Range(0, Food.Length);
				tamplate = Food[rndNum];
				break;
			default:
				break;
		}
		GameObject obj = Instantiate(tamplate);

		Debug.Log(this.transform.position.x);
		Debug.Log(this.transform.localScale.x);
		Debug.Log(obj.transform.localScale.y);
		obj.transform.localPosition = new Vector3(
			Random.Range(this.transform.position.x - 12, this.transform.position.x + 12),
			this.transform.position.y + obj.transform.localScale.y / 2,
			0
		);
	}
}
