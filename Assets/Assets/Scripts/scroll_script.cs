using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class scroll_script : MonoBehaviour {

	public float speed = 1.0f;
	private List<Transform> childParts;

	// Use this for initialization
	void Start () {
		// Get handle to child objects
		childParts = new List<Transform> ();
		for(int i=0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			childParts.Add(child);
		}

		// Sort from left to right
		childParts = childParts.OrderBy (
			t => t.position.x
		).ToList();
	
	}
	
	// Update is called once per frame
	void Update () {
		// Scoll object
		transform.Translate (new Vector3 (speed * -1, 0, 0) * Time.deltaTime);

		Transform firstChild = childParts.FirstOrDefault ();
		
		if (firstChild.position.x < Camera.main.transform.position.x) {
			
			if (!firstChild.renderer.IsVisibleFrom(Camera.main)) {
				Transform lastChild = childParts.LastOrDefault();
				Vector3 lastPosition = lastChild.transform.position;
				Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
				
				firstChild.position = new Vector3(lastPosition.x + lastSize.x - 0.05f, firstChild.position.y, firstChild.position.z);
				
				childParts.Remove(firstChild);
				childParts.Add (firstChild);
				
			}
			
			
			
		}

	
	}

	void lateUpdate() {

	}



}
