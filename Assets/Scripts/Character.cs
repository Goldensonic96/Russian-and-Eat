﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	public bool finishedMovement = true;
    private Dish genericDish;
    private GameObject dishStatus;

	// Use this for initialization
	void Start () {
        genericDish = Dish.getEmptyDish();
        GameManager game = Object.FindObjectOfType<GameManager>();
		if (game.femaleCharacter == true){
			Animator animator;
			animator = this.GetComponent<Animator>();
			animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("AnimatorControllers/chef_female", typeof(RuntimeAnimatorController )));
		}
        dishStatus = GameObject.Find("PlayerDishStatus");
	}

	// Update is called once per frame
	void Update () {
        //dishStatus.GetComponentInChildren<Text>().text = genericDish.ToString(); ;
    }

    public void bakeDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.BAKED);
    }

    public void stoveCookDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.STOVE_COOKED);
    }

    public void boilDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.BOILED);
    }

    public void fryDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.FRIED);
    }

    public void addIngredientToDish(Ingredient ingredient)
    {
        genericDish.addIngredient(ingredient);
    }

    public bool submitCreatedDishToMatchOrderedDish(Dish orderedDish)
    {
        Debug.Log("Player's dish: " + genericDish.ToString());
        Debug.Log("Expected dish: " + orderedDish.ToString());
        bool dishesMatch = genericDish.Equals(orderedDish);
        string outp = dishesMatch ? "Requested dish successfully created!" : "Requested dish made incorrectly!";
        Debug.Log(outp);
        genericDish = Dish.getEmptyDish();
        return dishesMatch;
    }
}