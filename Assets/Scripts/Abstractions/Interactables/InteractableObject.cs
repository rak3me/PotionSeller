using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public virtual void Interact (InteractableObject other) {
		//print (this.GetType ().ToString () + " is interacting with " + other.GetType ().ToString ());
		print (gameObject.name + " is interacting with " + other.gameObject.name);
	}

	public virtual void ChangeState (int state) {

	}

}


	/*
	private Collider[] cols;
	//public Vector3 dir;

	public virtual void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			Interact (other.gameObject);
		}
	}

	// Update is called once per frame
	public virtual void FixedUpdate () {
		cols = Physics.OverlapSphere (transform.position + transform.up + Vector3.up / 2, 0.45f, LayerMask.NameToLayer("Player"));
		//Debug.DrawLine (transform.position + Vector3.up / 2, transform.position + transform.up + Vector3.up / 2, Color.red);
		//print(transform.position + transform.up + Vector3.up / 2);
		foreach (Collider item in cols) {
			print (item.name);
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			if (cols.Length > 0) {
				Interact (cols [0].gameObject);
			}
		}
	}

	public virtual void Interact (GameObject other) {
//		print (other.name);
	}

	public virtual void ChangeState (int state) {

	}
}
*/