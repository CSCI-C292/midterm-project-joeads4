﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public string recipeName;

    public List<Ingredient> RecipeIngredients = new List<Ingredient>();
}
