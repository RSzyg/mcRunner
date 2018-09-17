using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
	public float scrollSpeed = 2f;
	public float timeInterval = 0.016f;
	public GameObject[] Floor = new GameObject[3];

	private float width;
	private Vector3 floorStartPos;
	private GameObject FirstFloor;
	private GameObject SecondFloor;
	
	// Use this for initialization
	void Awake () {
		floorStartPos = Floor[0].transform.position;
		width = Floor[0].transform.localScale.x;

		FirstFloor = Instantiate(Floor[0], new Vector3(0, -4, 0), Quaternion.identity);

		int rndNum = Random.Range(0, 3);
		SecondFloor = Instantiate(Floor[rndNum], floorStartPos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        if (FirstFloor.transform.position.x <= - width + 0.01) {
			Destroy(FirstFloor);
			int rndNum = Random.Range(0, 3);
			FirstFloor = Instantiate(Floor[rndNum], floorStartPos, Quaternion.identity);
        }
		FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);

		if (SecondFloor.transform.position.x <= - width + 0.01) {
			Destroy(SecondFloor);
			int rndNum = Random.Range(0, 3);
			SecondFloor = Instantiate(Floor[rndNum], floorStartPos, Quaternion.identity);
        }
		SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
	}
}
