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
	public GameObject Floor;
	public GameObject EnergyBar;
    public Slider EnergySlider;
    public GameObject EnergyFill;
	public Text DisplayDistance;
	public Text EnergyDigit;
	public GameObject FirstFloor;
	public GameObject SecondFloor;
    public Text GameOverTitle;
    public Text GameOverTips;

    private bool mute;
	private float width;
	private float distance;
	private GameObject _player;
	private GameObject _firstFloor;
	private GameObject _secondFloor;
	private PlayerController _playerController;
	
	void Awake()
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

		width = Floor.GetComponent<SpriteRenderer> ().size.x;

		float playerPosX = -3;
		float playerPosY = Floor.transform.position.y + Player.transform.localScale.y / 2;
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

			EnergyDigit.text = "卡路里：" + (int)PlayerController.energy + "%";

            if (_firstFloor.transform.position.x <= -width * 3 / 4) {
				if (_firstFloor != null) {
					Destroy(_firstFloor);
				}
				_firstFloor = Instantiate(
					Floor,
					_secondFloor.transform.position + Vector3.right * width,
					Quaternion.identity
				);
				Debug.Log(_firstFloor);
			}

			if (_secondFloor.transform.position.x <= -width * 3 / 4) {
				if (_secondFloor != null) {
					Destroy(_secondFloor);
				}
				_secondFloor = Instantiate(
					Floor,
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
            if (_playerController.Deadstage == "Hit")
            {
                GameOverTitle.text = "……";
                GameOverTips.text = "少年！中秋节要加油锻炼哦，你已经连跨栏都跨不过去了";
            } else if (_playerController.Deadstage == "Fall")
            {
                GameOverTitle.text = "井底见";
                GameOverTips.text = "中秋节也不要做低头族哦";
            } else if (_playerController.Deadstage == "Slim")
            {
                GameOverTitle.text = "请充值卡路里";
                GameOverTips.text = "中秋节也要好好对自己哦";
            } else if (_playerController.Deadstage == "Fat")
            {
                GameOverTitle.text = "卡路里爆表咯";
                GameOverTips.text = "中秋节要记得节制饮食哈";
            }
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
