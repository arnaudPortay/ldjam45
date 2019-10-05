using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;
using TMPro;

using System.IO;

public class bootScript: MonoBehaviour
{
    public TextMeshProUGUI text2;

    private RectTransform rectTransform;

    private int newLineCount = 0;

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below

    private bool first = true;

    private int delay = 2;
    private float counter = 0.0f;
 
    void Start () {
        theSourceFile = new FileInfo ("Assets\\Texts\\bootText.txt");
        reader = theSourceFile.OpenText();
        text2 = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }
   
    void Update () {        

        if (counter >= delay)
        {
            if (text != null) 
            {
                text = reader.ReadLine();
                text2.text += "\r\n" + text;
                newLineCount++;
                if (newLineCount >= 20)
                {
                    rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 14f);
                } 
            }
            else if (first)
            {
                first = false;
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 14f);
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 14f);
            }
        }
        else
        {
            counter += Time.deltaTime;
        }
    }
}