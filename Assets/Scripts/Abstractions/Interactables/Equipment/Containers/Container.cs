using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : InteractableObject {

	public int state = 0;
	public List<Recipe> potentialRecipes;

	// Use this for initialization
	public virtual void Start () {
		potentialRecipes = new List<Recipe>(GetComponent<RecipeList> ().recipes);
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void EmptyContents () {
		potentialRecipes = new List<Recipe>(GetComponent<RecipeList> ().recipes);
		state = 0;
	}

	public virtual void AddIngredient (GameObject ingredient) {
		
		print ("Added ingredient!");

		Recipe myRecipe = null;
		//List<Recipe> listCopy = potentialRecipes;
		List<int> indicesToRemove = new List<int>(0);

		for (int i = 0; i < potentialRecipes.Count; i++) {
			if (state < potentialRecipes [i].steps.Count) {
				if (!(potentialRecipes[i].steps [state].ingredient.name.StartsWith (ingredient.name))) {
					indicesToRemove.Add (i);
				}
			}
		}

		for (int i = indicesToRemove.Count - 1; i >= 0; i--) {
			potentialRecipes.RemoveAt (indicesToRemove [i]);
		}



		/*foreach (Recipe item in potentialRecipes) {
			print ("Recipe: " + item.name);
			if (state < item.steps.Count && !(item.steps [state].ingredient.name.StartsWith(ingredient.name))) {
				indicesToRemove.Add(

			}
		}*/


		state++;

		if (potentialRecipes.Count == 1) {
			if (state >= potentialRecipes [0].steps.Count) {
				print ("Recipe for '" + potentialRecipes[0].name + "' complete!");
				EmptyContents ();
			}
		} else if (potentialRecipes.Count == 0) {
			print ("No recipe found. Emptying Container!");
			EmptyContents ();
		}
	}

	public override void ChangeState (int state) {

			//this.state++;
	}
}
