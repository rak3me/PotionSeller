using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Depricated. Used to be attached to each inventory slot, but there's really no need for that. This script is no longer used anywhere.
public class InventorySlot : MonoBehaviour {

	public GameObject currentItem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void SetItem (GameObject i) {
		//Quaternion is a Vector4 representation of rotation, as opposed to Vector3 Euler angles. Usually will use Quaternion.Euler to deal with these cause they weird af.
		currentItem = Instantiate (i, transform.position, Quaternion.identity) as GameObject; 
		currentItem.transform.SetParent (transform);
		currentItem.transform.localPosition = Vector3.zero;
		print ("Item set!");
	}

	public void MoveItem (int index) {

	}

	public void RemoveItem () {
		if (currentItem) {
			Destroy (currentItem);
		} else {
			print ("Error: No item to destroy!");
		}
	}

	public void PrintCurrentItemName () {
		if (currentItem) {
			print ("Item Name: " + currentItem.name);
		} else {
			print ("Item Name: Null");
		}
	}
}