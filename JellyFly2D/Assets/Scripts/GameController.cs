using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public float frequency = 1;
	public Text scoreText;
	public Text lifeText;
	public GameObject[] jellys;
	public GameObject plane;


	private int sumScore;
	private int sumLife;
	private float lastTime;
	private Animator animatorPlane;

	// Use this for initialization
	void Start () {
		sumScore = 0;
		sumLife = 10;
		animatorPlane = plane.GetComponent<Animator> ();

		if (frequency < 0.5f) {
			frequency = 0.5f;
		}
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Pontos: " + sumScore.ToString();
		lifeText.text = "Vidas: " + sumLife.ToString (); 

		if (!IsRunnig()) {
			return;
		}

		if ((Time.time - lastTime) > (1/frequency)) {
			lastTime = Time.time;

			int rnd = Random.Range(0, jellys.Length);
			Vector3 jellyPosition = new Vector3(12, Random.Range(-5.0f, 5.0f), 0);
			GameObject jelly = Instantiate(jellys [rnd], jellyPosition, Quaternion.identity);

			Rigidbody2D jellyRb = jelly.GetComponent<Rigidbody2D>();
			jellyRb.velocity = new Vector2 ((-1 * frequency * Random.Range(5.0f, 10.0f)), 0);
		}
		
	}

	public void AddScore(int points) {
		sumScore += points;
		Debug.LogWarning ("Total de pontos: " + this.sumScore.ToString());
	}

	public void DecLife(int points) {
		sumLife -= points;
		if (sumLife <= 0) {
			sumLife = 0;
			animatorPlane.SetBool ("dead",true);
		}
			
	}

	public bool IsRunnig() {
		return sumLife > 0;
	}

	public void ResetFase() {
		sumLife = 10;
		sumScore = 0;
		animatorPlane.SetBool ("dead",false);
		animatorPlane.SetBool ("underAttack",false);
		animatorPlane.SetBool ("eating",false);
	}
}
