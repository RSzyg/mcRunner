using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
	public bool gameRunning = false;
	public float scrollSpeed = 2f;
	public float timeInterval = 0.016f;
	public Button startButton;
	public GameObject Player;
	public GameObject[] Floor = new GameObject[3];
	public GameObject[] Obstacel = new GameObject[2];

	private float width;
	private Vector3 floorStartPos;
	private GameObject FirstFloor;
	private GameObject SecondFloor;
	
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

		FirstFloor = Instantiate(Floor[0], new Vector3(0, -4, 0), Quaternion.identity);

		float playerPosX = -3;
		float playerPosY = Floor[0].transform.position.y + Player.transform.localScale.y / 2;
		float playerPosZ = 0;
		Instantiate(Player, new Vector3(playerPosX, playerPosY, playerPosZ), Quaternion.identity);

		int rndNum = Random.Range(0, 3);
		SecondFloor = Instantiate(Floor[rndNum], floorStartPos, Quaternion.identity);
	}

	void Game() {
        if (FirstFloor.transform.position.x <= - width + 0.01) {
			Destroy(FirstFloor);
			int rndNum = Random.Range(0, 3);
			FirstFloor = Instantiate(Floor[rndNum], floorStartPos, Quaternion.identity);

			AddObstacle(FirstFloor);
        }
		FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);

		if (SecondFloor.transform.position.x <= - width + 0.01) {
			Destroy(SecondFloor);
			int rndNum = Random.Range(0, 3);
			SecondFloor = Instantiate(Floor[rndNum], floorStartPos, Quaternion.identity);

			AddObstacle(SecondFloor);
        }
		SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
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
