using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    DialogueParser parser;

    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public GameObject textBox;



    public string dialogue;



    [SerializeField] Transform slots;

    public string firstIngredient;
    public string secondIngredient;
    public string thirdIngredient;

    public GameObject slot01;
    public GameObject slot02;
    public GameObject slot03;


    void Start()
    {


        parser = GameObject.Find("DialogueManager").GetComponent<DialogueParser>();
        parser.lineNum = 0;
        print("line num: " + parser.lineNum);

        ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (parser.lineNum == 0)
        {
            ShowDialogue();
            parser.lineNum++;
        }


        if (dialogueUI == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ContinueDialogue();
            }
        }
    }



    public void ContinueDialogue()
    {
        ShowDialogue();

        parser.lineNum++;

        CloseUI();
    }

  

    public void ShowDialogue()
    {
        //ResetImages();
        ParseLine();
        UpdateUI();
    }



    void UpdateUI()
    {
        dialogueText.text = dialogue;
    }


    void ParseLine()
    {
        parser.currentSpeakerName = parser.FindSpeaker(parser.lineNum);
        dialogue = parser.GetContent(parser.lineNum);
        parser.currentSpeakerEmotion = parser.GetPose(parser.lineNum);
        DisplayImages();
    }


    public void ResetLineNum()
    {
        parser.lineNum = 0;
    }


    void ResetImages()
    {
        if (parser.currentSpeakerName != "")
        {
            GameObject character = GameObject.Find(parser.currentSpeakerName);

            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = null;
        }
    }


    void DisplayImages()
    {


        if (parser.currentSpeakerName != "")
        {

            GameObject character = GameObject.Find(parser.currentSpeakerName);

            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            
            switch (parser.currentSpeakerEmotion)
            {
                case "H":
                    currSprite.sprite = character.GetComponent<Character>().characterPoses[0];
                    Debug.Log("Happy");
                    break;

                case "S":
                    currSprite.sprite = character.GetComponent<Character>().characterPoses[1];
                    Debug.Log("Sad");
                    break;

                case "N":
                    currSprite.sprite = character.GetComponent<Character>().characterPoses[2];
                    Debug.Log("Neutral");
                    break;
            }

            SetSpritePositions(character);

            SetTextPosition();
        }


    }

    void SetSpritePositions(GameObject spriteObj)
    {
        spriteObj.gameObject.SetActive(true);
    }


    void SetTextPosition()
    {
        dialogueText.gameObject.SetActive(true);
        textBox.gameObject.SetActive(true);
    }

    void CloseUI()
    {
        if (dialogue == "")
        {
            //dialogueUI.gameObject.SetActive(false);

            textBox.gameObject.SetActive(false);

            parser.ClearLines();

            ResetLineNum();
        }
    }


    public void AssignIngredients()
    {
        if (slot01.transform.childCount > 0)
        {
            GameObject item = slot01.GetComponent<Slot>().item;
            firstIngredient = item.name;
            //Debug.Log(firstIngredient);
        }

        if (slot02.transform.childCount > 0)
        {
            GameObject item = slot02.GetComponent<Slot>().item;
            secondIngredient = item.name;
            //Debug.Log(secondIngredient);
        }
        if (slot03.transform.childCount > 0)
        {
            GameObject item = slot03.GetComponent<Slot>().item;
            thirdIngredient = item.name;
            //Debug.Log(thirdIngredient);
        }

        Debug.Log("Slot1: " + firstIngredient + " Slot 2: " + secondIngredient + " Slot 3: " + thirdIngredient);
        Debug.Log("Spreadsheet 1: " + parser.currentIngredientOne + " Spreadsheet 2: " + parser.currentIngredientTwo + " Spreadsheet 3: " + parser.currentIngredientThree);

        CheckRecipe();


    }


    public void CheckRecipe()
    {


        if (firstIngredient == parser.currentIngredientOne)
        {
            Debug.Log("Match");
            if (secondIngredient == parser.currentIngredientTwo)
            {
                Debug.Log("Match");
                if (thirdIngredient == parser.currentIngredientThree)
                {
                    Debug.Log("Recipe made");
                }
                else
                {
                    Debug.Log("Recipe failed");
                }
            }
        }

    }


    public void CheckType()
    {
        switch (parser.currentDialogueType)
        {
            case "Intro":
                Debug.Log("Intro");
                break;

            case "Positive":
                Debug.Log("Positive");
                break;

            case "Negative":
                Debug.Log("Negative");
                break;


        }
            
    }

}
