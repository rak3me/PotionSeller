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
		if (Input.GetKeyDown (KeyCode.I)) {
			GameObject myItem = ((GameObject)(ingredientList [Random.Range(0, 6)]));
			//print (myItem);
			AddItemToInventory (myItem);
		} else if (Input.GetKeyDown(KeyCode.R)) {
			RemoveItemAtIndexFromInventory (Random.Range (0, inventorySlots.Count));
		}
	}

	public void AddItemToInventory (GameObject i) {
		bool slotFound = false;
		int index = 0;
		foreach (Transform slot in inventorySlots) {
			InventorySlot currentSlot = slot.GetComponent<InventorySlot> ();

			if (currentSlot) {
				if (currentSlot.currentItem == null) {
					currentSlot.SetItem (i);
					slotFound = true;
					print (i.name + " added to slot " + index);
					currentSlot.PrintCurrentItemName ();
					break;
				}
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

		InventorySlot currentSlot = inventorySlots[index].GetComponent<InventorySlot> ();
		currentSlot.RemoveItem ();
	}

	public void RemoveLastItemFromInventory () {
		bool slotFound = false;
		for (int i = inventorySlots.Count - 1; i >= 0; i--) {
			InventorySlot currentSlot = inventorySlots[i].GetComponent<InventorySlot> ();
			if (currentSlot.currentItem) {
				currentSlot.RemoveItem ();
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
