using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Customer", menuName = "Customer")]
public class Customer : ScriptableObject
{

    public Sprite HappySprite;
    public Sprite SadSprite;
    public Sprite NeutralSprite;
    public Sprite EmptySprite;

    public Recipe favoriteRecipe;

    public ChatLine[] chatLines;
    public ChatLine[] positiveLines;
    public ChatLine[] negativeLines;

    [System.Serializable]
    public struct ChatLine
    {
        public Emotion emotion;
        public string content;
        

    }

    public enum Emotion { HAPPY, SAD, NEUTRAL }

}
