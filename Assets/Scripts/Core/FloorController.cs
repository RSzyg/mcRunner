using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
	public float scrollSpeed = 2f;
	public float timeInterval = 0.016f;
	public Transform Floor0;
	public Transform Floor1;
	public Transform Floor2;

	private float width;
	private GameObject FirstFloor;
	private GameObject SecondFloor;
	private double random;
	
	// Use this for initialization
	void Awake () {
		FirstFloor = Instantiate(Floor0, new Vector3(0, -4, 0), Quaternion.identity).gameObject;
		width = FirstFloor.transform.GetComponent<Renderer>().bounds.extents.x;
		random = 3 * Random.value;
		if (random < 1) {
			SecondFloor = Instantiate(Floor0, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
		} else if (random < 2) {
			SecondFloor = Instantiate(Floor1, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
		} else {
			SecondFloor = Instantiate(Floor2, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (FirstFloor.transform.position.x > - width * 2 + 0.01) {
            FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
        else {
			Destroy(FirstFloor);
            random = 3 * Random.value;
			if (random < 1) {
				FirstFloor = Instantiate(Floor0, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
			} else if (random < 2) {
				FirstFloor = Instantiate(Floor1, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
			} else {
				FirstFloor = Instantiate(Floor2, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
			}
			FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
		if (SecondFloor.transform.position.x > - width * 2 + 0.01) {
            SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
        else {
			Destroy(SecondFloor);
            random = 3 * Random.value;
			if (random < 1) {
				SecondFloor = Instantiate(Floor0, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
			} else if (random < 2) {
				SecondFloor = Instantiate(Floor1, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
			} else {
				SecondFloor = Instantiate(Floor2, new Vector3(15.99f, -4, 0), Quaternion.identity).gameObject;
			}
			SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
        }
	}
}
