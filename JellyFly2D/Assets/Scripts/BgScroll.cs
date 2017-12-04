using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {
	private Material material;
	private Vector2 offSet;
	private float posicao = 0;
	public float velocidade = 0;
	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		posicao += velocidade;
		material.mainTextureOffset = new Vector2(posicao,0);
	}
}
