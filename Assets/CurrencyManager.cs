//Purpose: Static class that handles currency and transactions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrencyManager {
	private static int money;
	private static int gold;
	private static int silver;
	private static int copper;

	public static void AddAmount (int amount) {
		money += amount;
		UpdateCurrency ();
	}

	private static void UpdateCurrency () {
		gold = (money / 10000) % 100;
		silver = (money / 100) % 100;
		copper = money % 100;
	}

	public static int GetCurrentMoney () {
		return money;
	}

	public static int GetCurrentGold () {
		return gold;
	}

	public static int GetCurrentSilver () {
		return silver;
	}

	public static int GetCurrentCopper () {
		return copper;
	}
}
