using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Customer[] Customers;

    [SerializeField] Transform slots;

    public List<Ingredient> CurrentMixIngredients = new List<Ingredient>();

    public Recipe currentRecipe;
    public Customer currentCustomer;

    public GameObject Mocha;
    public GameObject ChaiLatte;
    public GameObject CocoaTea;
    public GameObject Unknown;

    public Sprite currSprite;

    public TMP_Text dialogueText;

    public string dialogue;



    public int lineNum;


    private void Start()

    {
        currentCustomer = Customers[0];
        currentRecipe = Customers[0].favoriteRecipe;
        //(CurrentCustomer.ChatLine[currentIndex].emotion) {
        //case Emotion.HAPPY:
        // load CurrentCustomer.HappyGraphic into customer UI graphic

        ReadLines();
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

                switch (currentRecipe.recipeName)
                {
                    case "Chai Latte":
                        ChaiLatte.gameObject.SetActive(true);
                        break;

                    case "Cocoa Tea":
                        CocoaTea.gameObject.SetActive(true);
                        break;

                    case "Mocha":
                        Mocha.gameObject.SetActive(true);
                        break;
                }

            }

            else
            {
                Debug.Log("You made an unknown drink!");

                Unknown.gameObject.SetActive(true);
            }


        }
 
    }


    void DisplayImages()
    {



    }
    private void ReadLines()
    {
        //currSprite = spriteDisplay;
        for (int i = 0; i < currentCustomer.chatLines.Length; i++)
        {
            dialogue = currentCustomer.chatLines[i].content;
            Debug.Log("dialogue: " + dialogue);

            Customer.Emotion currentEmotion = currentCustomer.chatLines[i].emotion;
            switch (currentEmotion)
            {
                case Customer.Emotion.HAPPY:
                    currSprite = currentCustomer.HappySprite;
                    Debug.Log("Happy");
                    break;

                case Customer.Emotion.SAD:
                    currSprite = currentCustomer.SadSprite;
                    Debug.Log("Sad");
                    break;

                case Customer.Emotion.NEUTRAL:
                    currSprite = currentCustomer.NeutralSprite;
                    Debug.Log("Neutral");
                    break;

            }
        }


    }


    void UpdateUI()
    {
        dialogueText.text = dialogue;
    }

}

