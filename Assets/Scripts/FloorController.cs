using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

	public GameObject[] Obstacle;
	public GameObject[] Food;

	private float range = 15.0f;

	// Use this for initialization
	void Start () {
		range -= (MainController.scrollSpeed - MainController.initialSpeed) / 2;
		float posX = 0;
		int objectNum = 1;

		if (range >= 13 && range <= 15) {
			objectNum = 3;
		} else if (range >= 10 && range < 13) {
			objectNum = 2;
		} else if (range < 10) {
			objectNum = 1;
		}

		for (int i = 0; i < objectNum; i++) {
			int type = Random.Range(0, 8);
			int rndNum = 0;
			GameObject tamplate = Obstacle[0];

			if (PlayerController.energy < 20) {
				if (type % 4 == 0) {
					rndNum = Random.Range(0, Obstacle.Length);
					tamplate = Obstacle[rndNum];
				} else {
					rndNum = Random.Range(0, Food.Length);
					tamplate = Food[rndNum];
				}
			} else {
				if (type % 2 == 0) {
					rndNum = Random.Range(0, Obstacle.Length);
					tamplate = Obstacle[rndNum];
				} else {
					rndNum = Random.Range(0, Food.Length);
					tamplate = Food[rndNum];
				}
			}
			GameObject obj = Instantiate(tamplate);

			obj.transform.parent = transform;

			float start = (-range + i * range * 2 / objectNum) * obj.transform.localScale.x;
			float end = start + (range * 2 / objectNum - (6 - objectNum) * 2) * obj.transform.localScale.x;
			if (objectNum == i + 1) {
				end = range * obj.transform.localScale.x;
			}
			posX = Random.Range(start, end);
			float posY = obj.transform.localScale.y / 2;
			if (obj.gameObject.tag == "RoadFence") {
				posY = obj.transform.localScale.y / 5;
			}
			if (obj.gameObject.tag == "BreakableObstacle" || obj.gameObject.tag == "Food") {
				posY = obj.transform.localScale.y / 3;
			}
			if (obj.gameObject.tag == "ManholeCover") {
				posY = obj.transform.localScale.y / 6;
			}
			obj.transform.localPosition = new Vector3(posX, posY, 0);
		}
	}

	// private void OnBecameInvisible()
	// {
	// 	Destroy(gameObject);
	// }
}
