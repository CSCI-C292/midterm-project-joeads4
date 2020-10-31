using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixIngredients : MonoBehaviour
{

    [SerializeField] Transform slots;

    public Recipe recipe;
    public DialogueParser parser;

    string firstIngredient;
    string secondIngredient;
    string thirdIngredient;
    string recipeName;
    
    public GameObject slot01;
    public GameObject slot02;
    public GameObject slot03;

    private void Start()
    {
        recipeName = parser.currentRecipe;
        Debug.Log("name: " + recipeName);
    }
    public void AssignIngredients()
    {
        

        if (transform.childCount > 0)
        {
            if(slot01.transform.childCount > 0)
            {
                GameObject item = slot01.GetComponent<Slot>().item;
                firstIngredient = item.name;
                Debug.Log(firstIngredient);
            }

            if (slot02.transform.childCount > 0)
            {
                GameObject item = slot02.GetComponent<Slot>().item;
                secondIngredient = item.name;
                Debug.Log(secondIngredient);
            }
            if (slot03.transform.childCount > 0)
            {
                GameObject item = slot03.GetComponent<Slot>().item;
                thirdIngredient = item.name;
                Debug.Log(thirdIngredient);
            }

            CheckRecipe();
        }
    }


    public void CheckRecipe()
    {
        


        //if (recipeName == recipe.ToString())
        //{
        //    Debug.Log("Recipe matches");

        //    if (firstIngredient == recipe.firstIngredient)
        //    {
        //        if (secondIngredient == recipe.secondIngredient)
        //        {
        //            if (thirdIngredient == recipe.thirdIngredient)
        //            {
        //                print("Recipe Made");
        //            }
        //        }
        //    }


        //    else Debug.Log("Wrong" + firstIngredient + secondIngredient + thirdIngredient);
        //}
    }
  
}
