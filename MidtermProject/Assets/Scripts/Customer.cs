using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Customer", menuName = "Customer")]
public class Customer : ScriptableObject
{

    public Texture2D HappySprite;
    public Texture2D SadSprite;
    public Texture2D NeutralSprite;

    public Recipe favoriteRecipe;

    public ChatLine[] ChatLines;

    [System.Serializable]
    public struct ChatLine
    {
        public Emotion emotion;

        public string text;
    }


    public enum Emotion { HAPPY, SAD, NEUTRAL }
}
