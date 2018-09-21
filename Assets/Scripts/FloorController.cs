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

			obj.transform.parent = transform;

			posX = Random.Range(-12 * obj.transform.localScale.x, 12 * obj.transform.localScale.x);

			obj.transform.localPosition = new Vector3(posX, obj.transform.localScale.y / 2, 0);
		// }
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
