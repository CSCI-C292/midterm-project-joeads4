using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public new string name;
    public Sprite icon;

    public string firstIngredient;
    public string secondIngredient;
    public string thirdIngredient;

}
