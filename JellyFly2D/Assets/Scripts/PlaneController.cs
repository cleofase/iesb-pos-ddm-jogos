using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {
    private Rigidbody2D rb; 

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow))
        {
			rb.AddForce(new Vector2(0, 0.5f),ForceMode2D.Impulse);
            //rigidBoby2D.AddForce(Vector2.up);

            return;
        }

		if (Input.GetKey(KeyCode.DownArrow))
		{
			rb.AddForce(new Vector2(0, -0.5f),ForceMode2D.Impulse);
			//rigidBoby2D.AddForce(Vector2.up);

			return;
		}


    }


}
