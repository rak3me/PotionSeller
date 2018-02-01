using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList : MonoBehaviour {
	public List<Recipe> recipes;

}

[System.Serializable]
public class Recipe {
	public string name;
	public List<Step> steps;


}

[System.Serializable]
public struct Step {
	public GameObject ingredient;
	[Range(0, 100)] public float duration;
}