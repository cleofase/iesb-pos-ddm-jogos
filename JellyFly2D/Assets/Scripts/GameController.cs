using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public float frequency = 1;
	public int initialScore;
	public int maxScore;
	public int life;
	public int fase;
	public bool lastFase = false;

	public Text scoreText;
	public Text lifeText;
    public Text resumeText;
	public GameObject[] jellys;
	public GameObject plane;
	public GameObject gameOver;
    public GameObject youWin;

	private float lastTime;
	private Animator animatorPlane;
	private int score;

	// Use this for initialization
	void Start () {
		animatorPlane = plane.GetComponent<Animator> ();
		score = initialScore;

		if (frequency < 0.5f) {
			frequency = 0.5f;
		}
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Pontos: " + score.ToString();
		lifeText.text = "Vidas: " + life.ToString (); 

		if (IsDead()) {
            positionGameOver();
            tryResumeGame();
            return;
		}

		if (IsWinner()) {
            positionYouWin();
            tryResumeGame();
			return;
		}

		if (canChangeFase()) {
			changeFase ();
			return;
		}

		if ((Time.time - lastTime) > (1/frequency)) {
			lastTime = Time.time;
			generateJelly ();
		}
		
	}

	private void generateJelly() {
		int rnd = Random.Range(0, jellys.Length);
		Vector3 jellyPosition = new Vector3(12, Random.Range(-5.0f, 5.0f), 0);
		GameObject jelly = Instantiate(jellys [rnd], jellyPosition, Quaternion.identity);
		Rigidbody2D jellyRb = jelly.GetComponent<Rigidbody2D>();
		float mimVelocity = 1.500f;
		float maxVelocity = mimVelocity + fase + 3.5000f;
		jellyRb.velocity = new Vector2 ((-1 * frequency * Random.Range(mimVelocity, maxVelocity)), 0);
	}

	private void positionGameOver() {
		Transform trans =  gameOver.GetComponent<Transform> ();
		Vector3 postion = new Vector3(0, 0, 0);
		trans.position = postion;
        resumeText.text = "Press <Space bar> to resume...";
	}

    private void positionYouWin() {
        Transform trans = youWin.GetComponent<Transform>();
        Vector3 postion = new Vector3(0, 0, 0);
        trans.position = postion;
        resumeText.text = "Press <Space bar> to resume...";
    }

    private bool canChangeFase() {
		return (score >= maxScore);
	}

	private void changeFase() {
		if (!lastFase) {
			fase += 1;
			SceneManager.LoadScene ("Fase0" + fase.ToString ());
		} else {
			// winner
			animatorPlane.SetBool ("winner",true);
		}
	}

    private void tryResumeGame() {
        if (Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene("Menu");
        }
    }


	public void AddScore(int points) {
		score += points;
	}

	public void DecLife(int points) {
		life -= points;
		if (life <= 0) {
			life = 0;
			animatorPlane.SetBool ("dead",true);
		}
			
	}

	public bool IsDead() {
		return animatorPlane.GetBool("dead");
	}

	public bool IsWinner() {
		return animatorPlane.GetBool("winner");
	}

	public bool IsRunning() {
		return (life > 0);
	}

	public void ResetFase() {
		life = 10;
		score = 0;
		animatorPlane.SetBool ("dead",false);
		animatorPlane.SetBool ("underAttack",false);
		animatorPlane.SetBool ("eating",false);
	}

}
