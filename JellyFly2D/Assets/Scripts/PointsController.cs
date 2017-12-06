using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour {
	public GameController gameController;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.LogWarning(other.tag);

		Animator planeAnimator = GetComponent<Animator> ();

		if (other.tag == "JellyRedTag") {
			gameController.DecLife(1);
			planeAnimator.SetBool ("underAttack", true);
		} else if (other.tag == "jellyGreenTag") {
			gameController.AddScore(1);
			planeAnimator.SetBool ("eating",true);
		}
		Destroy(other.gameObject);
	}
}
