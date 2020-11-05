using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

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

    public int lineNum;

    public int speakerNum;

    public int completed;

    public Button brewButton;

    public GameObject EndGame;

    public Customer.ChatLine[] currentChatLine;

    private void Start()

    {

        

        speakerNum = 0;
        completed = 0;

        currentCustomer = Customers[speakerNum];
        currentRecipe = Customers[speakerNum].favoriteRecipe;
        //(CurrentCustomer.ChatLine[currentIndex].emotion) {
        //case Emotion.HAPPY:
        // load CurrentCustomer.HappyGraphic into customer UI graphic

        lineNum = 0;

        currentChatLine = currentCustomer.chatLines;

        ShowDialogue();

        if (lineNum == 0)
        {
            ShowDialogue();
            lineNum++;
        }

    }


    private void Update()
    {
        

        if (dialogueUI.activeSelf)
        {
            brewButton.gameObject.SetActive(false);

            


            if (Input.GetKeyDown("space"))
            {
                
                ContinueDialogue();
            }
        }
        else
        {
            brewButton.gameObject.SetActive(true);
        }

        if (speakerNum == 2 && completed == 2)
        {
            spriteDisplay.sprite = null;
            EndGame.SetActive(true);
        }

        if (!dialogueUI.activeSelf)
        {
            if (Input.GetKeyDown("space"))
            {
                return;
            }

            if (completed == 2)
            {
                lineNum = 0;

                completed = 0;

                //

                //

                if (speakerNum <= 1)
                {
                    
                    speakerNum = speakerNum + 1;
                    spriteDisplay.sprite = null;

                    StartCoroutine(NewCustomerEnter());

                }

                ChaiLatte.SetActive(false);
                CocoaTea.SetActive(false);
                Mocha.SetActive(false);
                Unknown.SetActive(false);

                

            }
        }
  
        
    }

    private IEnumerator NewCustomerEnter()
    {
        yield return new WaitForSeconds(5);
        currentCustomer = Customers[speakerNum];
        currentRecipe = Customers[speakerNum].favoriteRecipe;
        currentChatLine = currentCustomer.chatLines;
        if (lineNum == 0)
        {
            ShowDialogue();
            lineNum++;

        }
    }

    void ShowDialogue()
    {
        //
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
        bool isEqual = Enumerable.SequenceEqual(CurrentMixIngredients, currentRecipe.RecipeIngredients);
        if (isEqual)
        {
            Debug.Log("You made a " + currentRecipe.recipeName + "!");
            currentChatLine = currentCustomer.positiveLines;
            dialogue = currentChatLine[lineNum].content;

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

            currentChatLine = currentCustomer.negativeLines;
            dialogue = currentChatLine[lineNum].content;


            Unknown.gameObject.SetActive(true);
        }


        dialogueUI.SetActive(true);
        ShowDialogue();

    }


    void DisplayImages()
    {

        if (currentEmotion != "")

            currentEmotion = currentChatLine[lineNum].emotion.ToString();
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

    public string GetContent(int lineNumber)
    {
        if (lineNumber < currentCustomer.chatLines.Length)
        {
            return currentChatLine[lineNumber].content;
        }
        return "";
    }

    public string GetPose(int lineNumber)
    {
        if (lineNumber < currentCustomer.chatLines.Length)
        {
            return currentChatLine[lineNumber].emotion.ToString();
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
        dialogueUI.SetActive(true);
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
    
    public void ClearList()
    {
        CurrentMixIngredients.Clear();
    }

    public void ResetImages()
    {
        spriteDisplay.sprite = null;

    }


    public void ResetLineNum()
    {
        lineNum = 0;
    }

    void CloseUI()
    {
        if (dialogue == "")
        {
            dialogueUI.gameObject.SetActive(false);
            completed++;

            //textBox.gameObject.SetActive(false);

            //Array.Clear(currentCustomer.chatLines, 0, currentCustomer.chatLines.Length);
            Debug.Log("Speaker Number: " + speakerNum);

            ResetLineNum();
            //ResetImages();

            ClearList();
        }
    }
}

