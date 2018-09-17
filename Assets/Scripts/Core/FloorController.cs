using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
	public float scrollSpeed = 2f;
	public float timeInterval = 0.016f;
	public GameObject[] Floor = new GameObject[3];

	private float width;
	private GameObject FirstFloor;
	private GameObject SecondFloor;
	
	// Use this for initialization
	void Awake () {
		FirstFloor = Instantiate(Floor[0], new Vector3(0, -4, 0), Quaternion.identity);
		width = FirstFloor.transform.GetComponent<Renderer>().bounds.extents.x;

		int rndNum = Random.Range(0, 3);
		SecondFloor = Instantiate(Floor[rndNum], new Vector3(15.99f, -4, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        if (FirstFloor.transform.position.x > - width * 2 + 0.01) {
            FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
        else {
			Destroy(FirstFloor);
			int rndNum = Random.Range(0, 3);
			FirstFloor = Instantiate(Floor[rndNum], new Vector3(15.99f, -4, 0), Quaternion.identity);
			FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
		if (SecondFloor.transform.position.x > - width * 2 + 0.01) {
            SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
        else {
			Destroy(SecondFloor);
			int rndNum = Random.Range(0, 3);
			SecondFloor = Instantiate(Floor[rndNum], new Vector3(15.99f, -4, 0), Quaternion.identity);
			SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
	}
}
