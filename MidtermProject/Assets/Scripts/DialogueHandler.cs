﻿using System.Collections;
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
    string emotion;

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
        emotion = parser.GetPose(parser.lineNum);
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
            int pose = 0;
            //emotion = character.GetComponent<Character>().characterPoses.Values(pose)
            // print("charName: " + load.currentSpeakerName);



            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = character.GetComponent<Character>().characterPoses[0];



            switch (emotion)
            {
                case "H":
                    //happy portrait
                    break;

                case "S":
                    //sad portrait
                    break;

                case "N":
                    //neutral portrait
                    break;
            }

            SetSpritePositions(character);

            SetTextPosition(dialogueText);
        }


    }

    void SetSpritePositions(GameObject spriteObj)
    {
        spriteObj.transform.position = new Vector3(-210, -70);
    }


    void SetTextPosition(TMP_Text textPos)
    {
        textPos.transform.position = new Vector3(-190, 100, -200);
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