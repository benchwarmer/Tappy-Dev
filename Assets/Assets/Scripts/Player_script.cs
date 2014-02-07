using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {

	public Vector2 jumpSpeed = new Vector2(50, 0);
	private bool jump;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		jump = Input.GetButtonDown ("Fire1");

		// Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		var topBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 1, 0)
		).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, 0)
		).y;

		transform.position = new Vector3 (
			transform.position.x,
			Mathf.Clamp (transform.position.y, bottomBorder, topBorder),
			transform.position.z
		);



	}

	void FixedUpdate() {
		if (jump) {
			rigidbody2D.AddForce(jumpSpeed);
		}

	}
}
