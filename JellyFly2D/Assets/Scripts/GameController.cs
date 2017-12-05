using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public float frequency = 1;
	public Text placar;
	public GameObject[] jellys;

	int sumPoints = 0;
	float lastTime;

	// Use this for initialization
	void Start () {
		if (frequency < 0.5f) {
			frequency = 0.5f;
		}
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		placar.text = "Pontos: " + sumPoints.ToString();

		if ((Time.time - lastTime) > (1/frequency)) {
			lastTime = Time.time;

			int rnd = Random.Range(0, jellys.Length);
			Vector3 jellyPosition = new Vector3(12, Random.Range(-5.0f, 5.0f), 0);
			GameObject jelly = Instantiate(jellys [rnd], jellyPosition, Quaternion.identity);

			Rigidbody2D jellyRb = jelly.GetComponent<Rigidbody2D>();
			jellyRb.velocity = new Vector2 ((-1 * frequency * Random.Range(5.0f, 10.0f)), 0);
		}
		
	}

	public void AddPoints(int points) {
		this.sumPoints += points;
		Debug.LogWarning ("Total de pontos: " + this.sumPoints.ToString());
	}
}
