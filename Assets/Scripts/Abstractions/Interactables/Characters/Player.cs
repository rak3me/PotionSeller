using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	Collider[] cols;
	Transform pickupPoint;
	[SerializeField] LayerMask pickupLayer;

	// Use this for initialization
	void Awake () {
		pickupPoint = transform.Find ("PickupPoint");
	}
	
	// Update is called once per frame
	void Update () {
		cols = Physics.OverlapSphere (pickupPoint.position, 0.25f, pickupLayer);
		//Debug.DrawLine (transform.position + Vector3.up / 2, transform.position + transform.up + Vector3.up / 2, Color.red);
		//print(transform.position + transform.up + Vector3.up / 2);
		foreach (Collider item in cols) {
//			print (item.name);
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			print ("Attempting pick up!");
			if (cols.Length > 0) {
				print ("Picking up a " + cols [0].name);
				InteractableObject other = cols [0].GetComponent<InteractableObject> ();
				if (other) {
					print ("Calling Interact");
					Interact (other);
				}
			} else {
				print ("Nothing in range!");
			}
		}
	}
}
