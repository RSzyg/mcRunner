using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

	public GameObject[] Obstacle;
	public GameObject[] Food;

	// Use this for initialization
	void Start () {
		float posX = 0;

		// for (int i = 0; i < 2; i++) {
			int type = Random.Range(0, 6);
			int rndNum = 0;
			GameObject tamplate = Obstacle[0];

			if (PlayerController.energy < 20) {
				if (type == 0 || type == 2) {
					rndNum = Random.Range(0, Obstacle.Length);
					tamplate = Obstacle[rndNum];
				} else {
					rndNum = Random.Range(0, Food.Length);
					tamplate = Food[rndNum];
				}
			} else {
				if (type == 0 || type == 2 || type == 4) {
					rndNum = Random.Range(0, Obstacle.Length);
					tamplate = Obstacle[rndNum];
				} else {
					rndNum = Random.Range(0, Food.Length);
					tamplate = Food[rndNum];
				}
			}
			GameObject obj = Instantiate(tamplate);

			obj.transform.parent = transform;

			posX = Random.Range(-12 * obj.transform.localScale.x, 12 * obj.transform.localScale.x);

			obj.transform.localPosition = new Vector3(posX, obj.transform.localScale.y / 2, 0);
		// }
	}

	// private void OnBecameInvisible()
	// {
	// 	Destroy(gameObject);
	// }
}
