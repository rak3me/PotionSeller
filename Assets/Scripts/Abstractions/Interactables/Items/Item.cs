using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : InteractableObject {

	public string name;

	//Temporary solution for displaying item names
	void OnGUI () {
		Vector2 pos = transform.parent.position;
		Vector2 scale = transform.parent.localScale;
		GUI.TextField (new Rect (new Vector2(pos.x - 35, Screen.height - pos.y + 25), new Vector2(70f, 20f)), name);
	}
}
