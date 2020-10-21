using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Sprite h = null;
    public Sprite s = null;
    public Sprite n = null;
    public Sprite e = null;

    public Dictionary<int, Sprite> characterPoses = new Dictionary<int, Sprite>();

    // Use this for initialization
    void Start()
    {
        characterPoses.Add(0, h);
        characterPoses.Add(1, s);
        characterPoses.Add(2, n);
        characterPoses.Add(3, e);
    }
}
