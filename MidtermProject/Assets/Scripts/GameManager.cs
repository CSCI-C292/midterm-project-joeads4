using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Customer[] Customers;

    [SerializeField] Transform slots;

    public List<Ingredient> CurrentMixIngredients = new List<Ingredient>();

    public Recipe currentRecipe;


    private void Start()

    {

        currentRecipe = Customers[0].favoriteRecipe;
        //(CurrentCustomer.ChatLine[currentIndex].emotion) {
        //case Emotion.HAPPY:
        // load CurrentCustomer.HappyGraphic into customer UI graphic
    }


    public void AssignIngredients()
    {
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {
                CurrentMixIngredients.Add(item.GetComponent<IngredientDisplay>().ingredient);
                //Debug.Log(CurrentMixIngredients);
            }
        }

        CheckRecipe();

        
    }

    void CheckRecipe()
    {
            
        for (int i = 0; i < CurrentMixIngredients.Count; i++)
        {
                if (CurrentMixIngredients[i] == currentRecipe.RecipeIngredients[i])
                {
                    Debug.Log("You made a " + currentRecipe.recipeName + "!");
                }
                else
                {
                    Debug.Log("You made an unknown drink!");
                }
                
        }

        

    }
}
