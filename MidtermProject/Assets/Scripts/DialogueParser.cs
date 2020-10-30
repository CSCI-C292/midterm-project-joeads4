using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{

    List<Dialogue> dialogues = new List<Dialogue>();


    public Dialogue d = new Dialogue();

    public int lineNum;

    public string currentSpeakerName;
    public string currentSpeakerContent;
    public string currentSpeakerEmotion;


    struct DialogueLine
    {
        public string name;
        public string content;
        public string emotion;


        public DialogueLine(string Name, string Content, string Emotion)
        {
            name = Name;
            content = Content;
            emotion = Emotion;
        }
    }

    List<DialogueLine> lines;
    void Start()
    {
        lineNum = 0;

        lines = new List<DialogueLine>();

        TextAsset dialogueData = Resources.Load<TextAsset>("Book1");

        string[] data = dialogueData.text.Split('\n');



        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split('\t');
            int.TryParse(row[0], out d.ID);
            d.SpeakerName = row[1];
            d.SpeakerEmotion = row[2];
            d.DialogueType = row[3];
            d.DialogueText = row[4];
            d.Recipe = row[5];
            dialogues.Add(d);
        }



        foreach (Dialogue d in dialogues)
        {
            //Debug.Log(d.SpeakerOneName);

            //print("Dialogue Text: " + d.DialogueText);

            string[] line = d.DialogueText.Split(';');


            foreach (string s in line)
            {
                //print("string: " + s);=

                string[] lineData = s.Split(']');

                for (int i = 0; i < lineData.Length; i++)
                {
                    //print("split on ]" + lineData[i]);
                }

                string[] charData = s.Split('-');

                for (int i = 0; i < charData.Length; i++)
                {
                    //print("split on -" + charData[i]);
                }


                DialogueLine lineEntry = new DialogueLine(charData[0].Substring(charData[0].IndexOf('[') + 1), lineData[1], charData[1].Substring(0, charData[1].IndexOf(']')));
                lines.Add(lineEntry);


                currentSpeakerName = lineEntry.name;
                currentSpeakerContent = lineEntry.content;
                currentSpeakerEmotion = lineEntry.emotion;


                print("line entry: " + "name: " + currentSpeakerName + "dialogue: " + currentSpeakerContent + "emotion: " + currentSpeakerEmotion);



            }


        }


    }


    public void ClearLines()
    {
        lines.Clear();
    }

    public string FindSpeaker(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].name;
        }


        return "";
    }


    public string GetContent(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].content;
        }
        return "";
    }

    public string GetPose(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].emotion;
        }
        return "";
    }

}
