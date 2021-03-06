﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ingredient : IComparable<Ingredient> {
    public Ingredient(Ingredient copy)
    {
        ingredientName =  copy.ingredientName;
        transliteration = copy.transliteration;
        russianName = copy.russianName;
    }

    public Ingredient(string ingredientName, string transliteration, string russianName, int price) {
        this.ingredientName = ingredientName;
        this.transliteration = transliteration;
        this.russianName = russianName;
        this.purchasePrice = price;
    }

    public Ingredient(string ingredientName)
    {
        this.ingredientName = ingredientName;
        transliteration = "N/A";
        russianName = "N/A";
    }

    public override string ToString()
    {
        return this.ingredientName + ", " +
               this.transliteration + ", " +
               this.russianName + ", " +
               this.purchasePrice;
    }

    public override bool Equals(object obj)
    {
        Ingredient other = obj as Ingredient;
        return ingredientName.Equals(other.ingredientName) &&
            transliteration.Equals(other.transliteration) &&
            russianName.Equals(other.russianName);
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + ingredientName.GetHashCode();
        hash = hash * 23 + transliteration.GetHashCode();
        hash = hash * 23 + russianName.GetHashCode();
        return hash;
    }

    public int CompareTo(Ingredient other)
    {
        return ingredientName.CompareTo(other.ingredientName);
    }

    public string getIngredientName() {
        return ingredientName;
    }

    public string getTransliteration()
    {
        return transliteration;
    }

    public string getRussianName()
    {
        return russianName;
    }

    public int getPurchasePrice()
    {
        return purchasePrice;
    }

    private string ingredientName;
    private string transliteration;
    private string russianName;
    private int purchasePrice;
}
