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
    }



    public void ContinueDialogue()
    {
        ShowDialogue();

        parser.lineNum++;

        CloseUI();
    }


    public void ShowDialogue()
    {
        ResetImages();
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
            //emotion = character.GetComponent<Character>().characterPoses.Values(pose)
            // print("charName: " + load.currentSpeakerName);


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
            dialogueUI.gameObject.SetActive(false);

            parser.ClearLines();

            ResetLineNum();
        }
    }
}
