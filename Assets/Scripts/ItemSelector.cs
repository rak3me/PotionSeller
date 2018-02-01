using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour {

	Ray ray;
	[SerializeField] RaycastHit hit;
	[SerializeField] GameObject currentItem;
	[SerializeField] LayerMask pickupLayer;

	Transform pickupPoint;
	Transform carryPoint;

	// Use this for initialization
	void Start () {
		currentItem = null;
		pickupPoint = transform.Find ("PickupPoint");
		carryPoint = transform.Find ("CarryPoint");
	}

	void OnGUI () {
		//DO THIS
	}

	void SetItem (GameObject item) {
		currentItem = item;
		currentItem.transform.parent = transform;
		currentItem.transform.position = carryPoint.position;
	}

	void RemoveItem () {
		//print ("Removing item...");
		Vector3 targPos = new Vector3 (transform.position.x + transform.forward.x / 2, currentItem.transform.localScale.y / 2, transform.position.z + transform.forward.z / 2);
		targPos = new Vector3 (Mathf.Round (targPos.x), targPos.y, Mathf.Round (targPos.z));

		Collider[] containers = Physics.OverlapSphere (targPos, 0.25f);
		Transform container = null;

		foreach (Collider item in containers) {
			if (item.tag == "Container") {
				container = item.transform;
				break;
			}
		}

		if (container) {
		//	print ("Container: " + container.name);
			container.GetComponent<Container> ().AddIngredient (currentItem);
			//container.GetComponent<Container> ().StartCoroutine("AddIngredient", currentItem);
			currentItem.transform.position = targPos;
			currentItem.transform.parent = null;
			Destroy (currentItem, 0.1f);
		} else {
		//	print ("Container: NONE");
			currentItem.transform.position = targPos;
			currentItem.transform.parent = null;
			currentItem = null;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Collider[] items = Physics.OverlapSphere (pickupPoint.position, 0.25f, pickupLayer);
			if (!currentItem) {
				//print ("Player does not currently have item.");
				if (items.Length > 0) {
				//	print ("There is an item that can be picked up.");
					SetItem (items [0].gameObject);
				} else {
				//	print ("There is not an item that can be picked up.");
				}
			} else {
				//print ("Player already has an item. Dropping it.");
				RemoveItem ();

				if (items.Length > 0) {
				//	print ("There was another item in range. Swapping.");
					SetItem (items [0].gameObject);
				}
			}
			//print ("---------------------------------------------------------------------------------------");
		}
	}
}
