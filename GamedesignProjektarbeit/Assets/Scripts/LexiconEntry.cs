using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LexiconData", menuName = "ScriptableObjects/LexiconData", order = 1)]
public class LexiconEntry : ScriptableObject
{

    public string fullName;
    public string fullDesciption;
    public GameObject prefab;
    public Sprite sprite;

}
