using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
	public bool gameRunning = false;
	public float scrollSpeed = 3f;
	public float timeInterval = 0.016f;
	public Button startButton;
	public GameObject Player;
	public GameObject[] Floor = new GameObject[3];
	public GameObject[] Obstacel = new GameObject[2];

	private float width;
	private Vector3 floorStartPos;
	private GameObject FirstFloor;
	private GameObject SecondFloor;
	private GameObject player;
	
	void Start()
	{
		startButton.onClick.AddListener(StartGame);
	}

	// Update is called once per frame
	void Update () {
		if (gameRunning) {
			Game();
		}
	}

	void StartGame() {
		startButton.gameObject.SetActive(false);
		gameRunning = true;

		floorStartPos = Floor[0].transform.position;
		width = Floor[0].transform.localScale.x;
		Debug.Log(width);

		FirstFloor = Instantiate(Floor[0], new Vector3(0, -4, 0), Quaternion.identity);

		float playerPosX = -3;
		float playerPosY = Floor[0].transform.position.y + Player.transform.localScale.y / 2;
		float playerPosZ = 0;
		player = Instantiate(
			Player,
			new Vector3(playerPosX, playerPosY, playerPosZ),
			Quaternion.identity
		);

		int rndNum = Random.Range(0, 3);
		SecondFloor = Instantiate(Floor[rndNum], floorStartPos, Quaternion.identity);
	}

	void Game() {
		if (player.GetComponent<PlayerController> ().isAlive) {
			if (scrollSpeed <= 9.5f) {
				scrollSpeed += 0.003f;
			}
			if (FirstFloor.transform.position.x <= - width + 0.01) {
				Destroy(FirstFloor);
				int rndNum = Random.Range(0, 3);
				FirstFloor = Instantiate(Floor[rndNum], SecondFloor.transform.position + Vector3.right * width, Quaternion.identity);

				AddObstacle(FirstFloor);
			}

			if (SecondFloor.transform.position.x <= - width + 0.01) {
				Destroy(SecondFloor);
				int rndNum = Random.Range(0, 3);
				SecondFloor = Instantiate(Floor[rndNum], FirstFloor.transform.position + Vector3.right * width, Quaternion.identity);

				AddObstacle(SecondFloor);
			}
			FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
			SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
		}
	}

	void AddObstacle(GameObject parentObj) {
		GameObject obj = Instantiate(Obstacel[0], new Vector3(0, 0, 0), Quaternion.identity);

		obj.transform.parent = parentObj.transform;

		float posX = 0;
		float posY = obj.transform.localScale.y / 2;
		float posZ = 0;

		obj.transform.localPosition = new Vector3(posX, posY, posZ);
	}
}
