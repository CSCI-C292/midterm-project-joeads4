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
    public string currentEmotion;

    public GameObject dialogueUI;
    public GameObject textBox;

    public GameObject Mocha;
    public GameObject ChaiLatte;
    public GameObject CocoaTea;
    public GameObject Unknown;

    public Sprite currSprite;

    public SpriteRenderer spriteDisplay;

    public TMP_Text dialogueText;

    public string dialogue;

    Customer.ChatLine[] chatLines;

    public int lineNum;


    private void Start()

    {
        currentCustomer = Customers[1];
        currentRecipe = Customers[1].favoriteRecipe;
        //(CurrentCustomer.ChatLine[currentIndex].emotion) {
        //case Emotion.HAPPY:
        // load CurrentCustomer.HappyGraphic into customer UI graphic

        lineNum = 0;

        

        ShowDialogue();
    }

    private void Update()
    {
        if (lineNum == 0)
        {
            ShowDialogue();
            lineNum++;
        }

        if (dialogueUI == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ContinueDialogue();
            }
        }
    }

    void ShowDialogue()
    {
        ParseLine();
        UpdateUI();
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
        
        

        if (currentEmotion != "")

            currentEmotion = currentCustomer.chatLines[lineNum].emotion.ToString();
        {
            Debug.Log("current emotion: " + currentEmotion);

            switch (currentEmotion)
            {
                case "HAPPY":

                    spriteDisplay.sprite = currentCustomer.HappySprite;
                    Debug.Log("Happy");
                    break;

                case "SAD":
                    spriteDisplay.sprite = currentCustomer.SadSprite;
                    Debug.Log("Sad");
                    break;

                case "NEUTRAL":
                    spriteDisplay.sprite = currentCustomer.NeutralSprite;
                    Debug.Log("Neutral");
                    break;

            }
        }


    }
    //private void ReadLines()
    //{
    //    //currSprite = spriteDisplay;
    //    for (int i = 0; i < currentCustomer.chatLines.Length; i++)
    //    {

    //        //dialogue = currentCustomer.chatLines[i].content;
    //        Debug.Log("dialogue: " + dialogue);

            
    //    }


    //}

    public string GetContent(int lineNumber)
    {
        if (lineNumber < currentCustomer.chatLines.Length)
        {
            return currentCustomer.chatLines[lineNumber].content;
        }
        return "";
    }

    public string GetPose(int lineNumber)
    {
        if (lineNumber < currentCustomer.chatLines.Length)
        {
            return currentCustomer.chatLines[lineNumber].emotion.ToString();
        }
        return "";
    }

    void ParseLine()
    {
        Debug.Log("Line num:" + lineNum);
        dialogue = GetContent(lineNum);
        Debug.Log("Line: " + dialogue);

        currentEmotion = GetPose(lineNum);

        DisplayImages();
    }
    void UpdateUI()
    {
        dialogueText.text = dialogue;
    }


    public void ContinueDialogue()
    {
        ShowDialogue();

        lineNum++;

        CloseUI();
        
    }
    

    public void ResetLineNum()
    {
        lineNum = 0;
    }

    void CloseUI()
    {
        if (dialogue == "")
        {
            //dialogueUI.gameObject.SetActive(false);

            textBox.gameObject.SetActive(false);

            

            ResetLineNum();
        }
    }
}

