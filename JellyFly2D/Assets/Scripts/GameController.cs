using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public float frequency = 1;
	public Text scoreText;
	public Text lifeText;
	public GameObject[] jellys;
	public GameObject plane;


	public int sumScore;
	public int faseAtual = 1;
	private bool mudouFase;
	public int sumLife = 10;
	private float lastTime;
	private Animator animatorPlane;

	// Use this for initialization
	void Start () {

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
			jellyRb.velocity = new Vector2 ((-1 * frequency * 3), 0); 	
			//Random.Range(5.0f, 10.0f)
		}
		
	}

	public void AddScore(int points) {
		sumScore += points;
		if (podeMudarFase()){
			Debug.LogWarning ("muda fase" );
			mudafase();
		}
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

	public bool podeMudarFase (){
		SceneManager.LoadScene ("fase atula Fase0"+faseAtual.ToString());
		SceneManager.LoadScene ("sumscore"+sumScore.ToString());
		return (sumScore == 10 && faseAtual == 1) || (sumScore == 20 && faseAtual == 2) || (sumScore == 30 && faseAtual == 3) || (sumScore == 40 && faseAtual == 4);
	}


	public void mudafase(){
		faseAtual += 1;
		if (faseAtual > 4) {
			Debug.LogWarning ("Ganhou");
		} else {
			Debug.LogWarning ("muda fase" + " Fase0"+faseAtual.ToString() );
			SceneManager.LoadScene ("Fase0"+faseAtual.ToString());
		}
	}


}
