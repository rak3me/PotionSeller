using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	[SerializeField] Transform currentItem;

	//Technical Variables for Trigger Detection
	Collider[] itemColliders;
	Collider[] environColliders;
	Transform pickupPoint;
	Transform carryPoint;
	[SerializeField] LayerMask pickupLayer;
	[SerializeField] LayerMask environmentLayer;

	// Use this for initialization
	void Awake () {
		pickupPoint = transform.Find ("PickupPoint"); //Player should have child of this name to easily determine and edit pickup location
		carryPoint = transform.Find ("CarryPoint"); //Player should have child of this name to easily determine and edit carry location
	}
	
	// Update is called once per frame
	void Update () {
		itemColliders = Physics.OverlapSphere (pickupPoint.position, 0.25f, pickupLayer); //List of all pickup-able colliders
		environColliders = Physics.OverlapSphere (pickupPoint.position, 0.25f, environmentLayer); //List of all pickup-able colliders

		//If the player presses the pickup button, check to see if there is a pickup-able item in range, and interact with the closest one if there is
		if (Input.GetKeyDown (KeyCode.E)) {
			if (itemColliders.Length > 0) {
				InteractableObject other = itemColliders [0].GetComponent<InteractableObject> ();
				if (other) {
					Interact (other);
				}
			} else if (environColliders.Length > 0) {
				print ("Doing environment shit");
				InteractableObject other = environColliders [0].GetComponent<InteractableObject> ();
				if (other) {
					Interact (other);
				}
			}
		}
	}

	public override void Interact (InteractableObject other) {
		//print ("Checking to see if " + other.name + " is an Item...");
		//other.GetType ().IsSubclassOf (typeof(Item));

		if (other.GetType ().IsSubclassOf (typeof(Item))) {
			//print ("It is an item!");
			if (!currentItem) {
				PickupItem (other.transform);
			} else {
				SwapItem (other.transform);
			}
		} else if (other.GetType ().IsSubclassOf (typeof(Environment))) {
			print ("Environment bae");
			if (currentItem) {
				PlaceItem (other.transform);
			}
		}
	}

	public void PickupItem (Transform other) {
		//print ("Picking up item!");
		currentItem = other;
		currentItem.SetPositionAndRotation (carryPoint.position, carryPoint.rotation);
		currentItem.SetParent (carryPoint);
	}

	public void SwapItem (Transform other) {
		//print ("Swapping item!");
		currentItem.parent = null;
		currentItem.SetPositionAndRotation (other.position, other.rotation);
		PickupItem (other);
	}

	public void PlaceItem (Transform other) {
		print ("Placing item!");
		currentItem.parent = null;
		currentItem.SetPositionAndRotation (other.position + Vector3.up * ((other.localScale.y / 2) + (currentItem.localScale.y / 2)), other.rotation);
		currentItem = null;
	}
}
