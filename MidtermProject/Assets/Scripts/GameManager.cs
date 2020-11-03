using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScriptableObject[] Customers = null;

    [SerializeField] Transform slots;

    public List<ScriptableObject> CurrentMixIngredients = new List<ScriptableObject>();


    private void Start()

    {

        
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
                Debug.Log(CurrentMixIngredients);
            }
        }

    }

    void CheckRecipe()
    {
        //CurrentMixIngredients.SequenceEqual(CurrentCustomer.favoriteRecipe)
    }
}
