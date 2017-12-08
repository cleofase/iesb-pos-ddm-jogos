using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneController : MonoBehaviour {
    private Rigidbody2D rb;
	private Animator animator;
	private float bottomLimit = -5.0f;
	private float topLimit = 5.0f;
	private float leftLimit = -9.0f;
	private float rightLimit = 9.0f;
	private float positionUnit = 0.1f;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
		Vector3 positionPlane = rb.transform.position;

		if (animator.GetBool ("dead")) {
			downPlane ();
			return;
		}

		if (animator.GetBool("winner")) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			positionUnit = 0.3f;
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			positionUnit = 0.1f;
		}


		if (Input.GetKey(KeyCode.UpArrow))
        {
			//rb.AddForce(new Vector2(0, 0.5f),ForceMode2D.Impulse);
			upPlane ();
            return;
        }

		if (Input.GetKey(KeyCode.DownArrow))
		{
			//rb.AddForce(new Vector2(0, -0.5f),ForceMode2D.Impulse);
			downPlane ();
			return;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//rb.AddForce(new Vector2(0, -0.5f),ForceMode2D.Impulse);
			leftPlane ();
			return;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			//rb.AddForce(new Vector2(0, -0.5f),ForceMode2D.Impulse);
			rightPlane ();
			return;
		}
    }

	private void downPlane() {
		Vector3 positionPlane = rb.transform.position;
		if (positionPlane.y > bottomLimit) {
			positionPlane.y -= positionUnit;
			rb.transform.position = positionPlane;
		}
	}

	private void upPlane() {
		Vector3 positionPlane = rb.transform.position;
		if (positionPlane.y < topLimit) {
			positionPlane.y += positionUnit;
			rb.transform.position = positionPlane;
		}
	}

	private void leftPlane() {
		Vector3 positionPlane = rb.transform.position;
		if (positionPlane.x > leftLimit) {
			positionPlane.x -= positionUnit;
			rb.transform.position = positionPlane;
		}
	}

	private void rightPlane() {
		Vector3 positionPlane = rb.transform.position;
		if (positionPlane.x < rightLimit) {
			positionPlane.x += positionUnit;
			rb.transform.position = positionPlane;
		}
	}

}
