using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Purpose: To open and close different UI elements
public class MenuManager : MonoBehaviour {

	private GameObject inventory;
	private GameObject shop;

	// Use this for initialization
	void Awake () {
		inventory = transform.Find ("Inventory").gameObject;
		shop = transform.Find ("Shop").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		//When the player presses this key, it will toggle inventory visibility
		if (Input.GetKeyDown (KeyCode.I)) {
			ToggleGameObject (inventory);

			if (shop.activeSelf) {
				ToggleGameObject (shop);
			}
		} else if (Input.GetKeyDown (KeyCode.O)) {
			ToggleGameObject (shop);

			if (inventory.activeSelf) {
				ToggleGameObject (inventory);
			}
		}
	}

	//Toggle inventory visibility
	public void ToggleGameObject (GameObject obj) {
		obj.SetActive (!obj.activeSelf);
	}
}
