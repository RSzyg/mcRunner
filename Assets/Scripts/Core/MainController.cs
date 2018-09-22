using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
	public bool gameRunning = false;
	public static float initialSpeed = 5.0f;
	public static float scrollSpeed = 5.0f;
	public GameObject Player;
	public GameObject GameOverUI;
	public GameObject[] Floor = new GameObject[3];
	public GameObject EnergyBar;
    public Slider EnergySlider;
    public GameObject EnergyFill;
	public Text DisplayDistance;
	public GameObject FirstFloor;
	public GameObject SecondFloor;

    private bool mute;
	private float width;
	private float distance;
	private GameObject _player;
	private GameObject _firstFloor;
	private GameObject _secondFloor;
	private PlayerController _playerController;
	
	void Start()
	{
		EnergyBar.SetActive(true);
		distance = 0.0f;
        mute = OptionmenuController.isPlaying;
        if (mute)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }

        scrollSpeed = 5.0f;
		gameRunning = true;
		_firstFloor = FirstFloor;
		_secondFloor = SecondFloor;

		width = Floor[0].transform.localScale.x;

		float playerPosX = -3;
		float playerPosY = Floor[0].transform.position.y + Player.transform.localScale.y / 2;
		float playerPosZ = 0;
		_player = Instantiate(
			Player,
			new Vector3(playerPosX, playerPosY, playerPosZ),
			Quaternion.identity
		);
		_playerController = _player.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 mousePos2D = new Vector2 (mousePos.x , mousePos.y);
			RaycastHit2D hit = Physics2D.Raycast (mousePos2D , Vector2.zero);

			bool hitPlayer = true;
			if (hit.collider != null) {
				if (hit.collider.gameObject.name == "PauseButton") {
					PauseGame();
					hitPlayer = false;
				} else if (hit.collider.gameObject.name == "Continue") {
					ContinueGame();
					hitPlayer = false;
				}
			}
			if (hitPlayer && _playerController.isAlive && !_playerController.jumping) {
				if (_player.GetComponent<Rigidbody2D> ().IsSleeping()) {
					return;
				}
				_playerController.jumping = true;
				_playerController.rb.velocity = new Vector2(_playerController.rb.velocity.x, 12.0f);
				_player.GetComponent<Animator> ().Play("Jumping");
			}
		}
		if (gameRunning) {
			Game();
		}
	}

	void Game() {
		if (_playerController.isAlive) {
			distance += scrollSpeed / 60;
			if (scrollSpeed <= 17) {
				scrollSpeed += 0.002f;
			}
            PlayerController.energy -= 0.02f;

			EnergySlider.value = PlayerController.energy / 100;
        
            if (PlayerController.energy < 20 || PlayerController.energy > 80)
            {
                EnergyFill.GetComponent<Image> ().color = Color.red;
            } else
            {
                EnergyFill.GetComponent<Image> ().color = Color.white;
            }

			DisplayDistance.text = "" + (int)distance;

            if (_firstFloor.transform.position.x <= -width * 3 / 4) {
				if (_firstFloor != null) {
					Destroy(_firstFloor);
				}
				int rndNum = Random.Range(0, 3);
				_firstFloor = Instantiate(
					Floor[rndNum],
					_secondFloor.transform.position + Vector3.right * width,
					Quaternion.identity
				);
				Debug.Log(_firstFloor);
			}

			if (_secondFloor.transform.position.x <= -width * 3 / 4) {
				if (_secondFloor != null) {
					Destroy(_secondFloor);
				}
				int rndNum = Random.Range(0, 3);
				_secondFloor = Instantiate(
					Floor[rndNum],
					_firstFloor.transform.position + Vector3.right * width,
					Quaternion.identity
				);
				Debug.Log(_secondFloor);
			}
			_firstFloor.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
			_secondFloor.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
		}
		else {
			_player.GetComponent<Animator> ().Play("Jumping");
            GetComponent<AudioSource>().Stop();
			GameOverUI.SetActive(true);
			gameRunning = false;
		}
	}

    void PauseGame()
    {
		_player.GetComponent<Rigidbody2D> ().Sleep();
        gameRunning = false;
        GetComponent<AudioSource>().Pause();
    }

	void ContinueGame() {
		_player.GetComponent<Rigidbody2D> ().WakeUp();
		gameRunning = true;
        GetComponent<AudioSource>().Play();
	}
}
