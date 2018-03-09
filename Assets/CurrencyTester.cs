//Purpose: Debug tests for currency

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Need to import this most times you use OnGUI() in a script

public class CurrencyTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("GetRich", 0.1f, 0.1f); //Calls GetRich once every 0.1 seconds	
	}
	
	// Update is called once per frame
	void Update () {
		CurrencyManager.AddAmount(7);
	}

	//Adds a small amount to player's money
	void GetRich () {
		//CurrencyManager.AddAmount (50);
	}

	//Special Unity specific function called every frame that allows you to dynamically add UI through a script, not in a Canvas
	//Generally not used, as it is harder to change specific things about how the UI looks from script. Only using for testing purposes.
	void OnGUI () {
		//Gets money values from CurrencyManager and puts them in a string to be displayed
		string text = "Total money: " + CurrencyManager.GetCurrentMoney ().ToString () + "   Gold: " + CurrencyManager.GetCurrentGold ().ToString () + "   Silver: " + CurrencyManager.GetCurrentSilver ().ToString () + "   Copper: " + CurrencyManager.GetCurrentCopper ().ToString ();
		GUI.TextField (new Rect (0f, 0f, 350f, 20f), text);
	}
}
