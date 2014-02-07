using UnityEngine;
using System.Collections;

public class Enemy_script : MonoBehaviour {

	public float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Scoll object
		transform.Translate (new Vector3 (moveSpeed * -1, 0, 0) * Time.deltaTime);


	
	}

	void onTriggerEnter2D(Collider2D collider) {
		Destroy (collider.gameObject);

	}
}
