using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour {
	public GameController gameController;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.LogWarning(other.tag);

		Animator planeAnimator = GetComponent<Animator> ();

		int points = 0;
		if (other.tag == "JellyRedTag") {
			points = -1;
			planeAnimator.SetBool ("underAttack", true);
		} else if (other.tag == "jellyGreenTag") {
			points = 1;
			planeAnimator.SetBool ("eating",true);
		}
		gameController.AddPoints(points);
		Destroy(other.gameObject);
	}
}
