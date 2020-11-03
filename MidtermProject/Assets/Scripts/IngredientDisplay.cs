using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisplay : MonoBehaviour
{
    public Ingredient ingredient;

    public Image ingredientImage;


    private void Start()
    {
        ingredientImage.sprite = ingredient.image;
    }
}
