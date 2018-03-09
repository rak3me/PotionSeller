//Purpose: Currently, tests functionality of adding and removing random items from the inventory
//TODO: Generalize, and add more functionality beyond adding and removing random items.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public List<Transform> inventorySlots;
	public Object[] ingredientList;

	// Use this for initialization
	void Awake () {
		foreach (Transform child in transform) {
			inventorySlots.Add (child);
		}
		ingredientList = Resources.LoadAll ("Prefabs/Ingredients");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			print ("Add Item to Inventory");
			GameObject myItem = ((GameObject)(ingredientList [Random.Range (0, 6)]));
			//print (myItem);
			AddItemToInventory (myItem);
		} else if (Input.GetKeyDown (KeyCode.R)) {
			print ("Remove Item from Inventory");
			RemoveItemAtIndexFromInventory (Random.Range (0, inventorySlots.Count));
		} else if (Input.GetKeyDown (KeyCode.I)) {
			//ToggleInventory ();
		}
	}

	public void AddItemToInventory (GameObject i) {
		bool slotFound = false;
		int index = 0;
		foreach (Transform slot in inventorySlots) {
			if (slot.childCount == 0) {
				Transform instance = Instantiate (i, Vector3.zero, Quaternion.identity).transform;
				instance.SetParent (slot);
				instance.localPosition = Vector3.zero;

				slotFound = true;
				break;
			}
			index++;
		}

		if (!slotFound) {
			print ("Inventory is full!");
		}
	}

	public void RemoveItemAtIndexFromInventory (int index) {
		if (index >= inventorySlots.Count) {
			print ("Error: Requested index bigger than inventory size!");
			return;
		}
			
		if (inventorySlots [index].childCount > 0) {
			Destroy (inventorySlots [index].GetChild (0).gameObject);
		}
	}

	public void RemoveLastItemFromInventory () {
		bool slotFound = false;
		for (int i = inventorySlots.Count - 1; i >= 0; i--) {
			if (inventorySlots[i].childCount > 0) {
				Destroy (inventorySlots [i].GetChild (0).gameObject);
				slotFound = true;
				break;
			}
		}

		if (!slotFound) {
			print ("No items to delete!");
		}
	}

	public void Sort (int type) {
		switch (type) {
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		default:
			break;
		}
	}
}
