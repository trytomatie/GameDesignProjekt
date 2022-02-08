using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMovement : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string textToAnimate;
    private int index = 1;
    private static float textSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        textToAnimate = text.text;
        InvokeRepeating("AnimateText", 0, textSpeed);
    }

    /// <summary>
    /// Animates 1 Character at at thime
    /// By Christian Scherzer
    /// </summary>
    private void AnimateText()
    {
        string textToPrint = "";
        for(int i = 0; i < index;i++)
        {
            textToPrint += textToAnimate[i];
        }
        text.text = textToPrint;
        index++;
        if(index == textToAnimate.Length)
        {
            CancelInvoke("AnimateText");
        }
    }
}
