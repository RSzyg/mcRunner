using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
	public bool gameRunning = false;
	public float scrollSpeed = 3f;
	public float timeInterval = 0.016f;
	public GameObject PauseUI;
	public GameObject Player;
	public GameObject[] Floor = new GameObject[3];
	public GameObject[] Obstacle = new GameObject[3];
	public GameObject[] Food = new GameObject[3];
    public Text DisplayEnergy;

	private float width;
	private GameObject FirstFloor;
	private GameObject SecondFloor;
	private GameObject _player;
	private PlayerController _playerController;
	
	private void Awake() {
		PauseUI.SetActive(false);
	}
	void Start()
	{
		scrollSpeed = 5.0f;

		gameRunning = true;

		width = Floor[0].transform.localScale.x;
		Debug.Log(width);

		FirstFloor = Instantiate(Floor[0], new Vector3(0, -4, 0), Quaternion.identity);

		float playerPosX = -3;
		float playerPosY = Floor[0].transform.position.y + Player.transform.localScale.y / 2;
		float playerPosZ = 0;
		_player = Instantiate(
			Player,
			new Vector3(playerPosX, playerPosY, playerPosZ),
			Quaternion.identity
		);
		_playerController = _player.GetComponent<PlayerController> ();

		int rndNum = Random.Range(0, 3);
		SecondFloor = Instantiate(Floor[rndNum], Floor[0].transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 mousePos2D = new Vector2 (mousePos.x , mousePos.y);
			RaycastHit2D hit = Physics2D.Raycast (mousePos2D , Vector2.zero);

			if (hit.collider != null) {
				if (hit.collider.gameObject.name == "Pause") {
					PauseGame();
				}
				if (hit.collider.gameObject.name == "Continue") {
					ContinueGame();
				}
			} else if (_playerController.isAlive && !_playerController.jumping) {
				if (_player.GetComponent<Rigidbody2D> ().IsSleeping()) {
					return;
				}
				_playerController.jumping = true;
				_playerController.rb.velocity = new Vector2(_playerController.rb.velocity.x, 12.0f);
			}
		}
		if (gameRunning) {
			Game();
		}
	}

	void Game() {
		if (_playerController.isAlive) {
			scrollSpeed += 0.002f;
            _playerController.energy -= 0.02f;
        
            if (_playerController.energy < 20)
            {
                DisplayEnergy.text = "<color=red>" + (int)_playerController.energy + "</color>";
            } else
            {
                DisplayEnergy.text = "<color=white>" + (int)_playerController.energy + "</color>";
            }

            if (FirstFloor.transform.position.x <= -width * 3 / 4) {
				Destroy(FirstFloor);
				int rndNum = Random.Range(0, 3);
				FirstFloor = Instantiate(
					Floor[rndNum],
					SecondFloor.transform.position + Vector3.right * width,
					Quaternion.identity
				);
			}

			if (SecondFloor.transform.position.x <= -width * 3 / 4) {
				Destroy(SecondFloor);
				int rndNum = Random.Range(0, 3);
				SecondFloor = Instantiate(
					Floor[rndNum],
					FirstFloor.transform.position + Vector3.right * width,
					Quaternion.identity
				);
			}
			FirstFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
			SecondFloor.transform.Translate(Vector3.left * scrollSpeed * timeInterval);
		}
	}

    void PauseGame()
    {
		_player.GetComponent<Rigidbody2D> ().Sleep();
		PauseUI.SetActive(true);
        gameRunning = false;
    }

	void ContinueGame() {
		_player.GetComponent<Rigidbody2D> ().WakeUp();
		PauseUI.SetActive(false);
		gameRunning = true;
	}
}
