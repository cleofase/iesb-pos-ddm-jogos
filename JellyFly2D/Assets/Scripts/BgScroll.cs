using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {
	public float velocity = 0;
	public GameController gameController;

	private Material material;
	private float offSet;
	private float velocityScroll;

	// Use this for initialization
	void Start () {
		velocityScroll = velocity;
		offSet = 0;
		material = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.IsRunnig ()) {
			if (velocityScroll <= 0) {
				velocityScroll = velocity;
			}
			offSet += velocityScroll;
			material.mainTextureOffset = new Vector2 (offSet, 0);
		} else {
			DecVelocityScroll ();
		}
			
	}

	void DecVelocityScroll() {
		if (velocityScroll > 0) {
			velocityScroll -= 0.01f;
		}

		if (velocityScroll < 0) {
			velocityScroll = 0.0f;
		}
	}
}
