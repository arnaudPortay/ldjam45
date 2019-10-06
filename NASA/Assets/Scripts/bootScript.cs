using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;
using TMPro;

using System.IO;
using UnityEngine.Events;

public class bootScript: MonoBehaviour
{
    private TextMeshProUGUI text2;

    private RectTransform rectTransform;

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " ";

    private string line = "";


    private int delay = 2;
    private float counter = 0.0f;
    
    public UnityEvent bootOver;

    public float waitTimeAfterBoot = 2.0f;
    private float timeAfterBoot = 0.0f;
 
    void Start () {
        theSourceFile = new FileInfo ("Assets\\Texts\\bootText.txt");
        reader = theSourceFile.OpenText();
        text2 = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }
   
    void Update () {        

        if (counter >= delay)
        {
            if (line != null) 
            {
                line = reader.ReadLine();
                text = text2.text + "\r\n" + line;

                // Check if text size is bigger than allowed size
                if (LayoutUtility.GetPreferredHeight(text2.rectTransform) >  rectTransform.rect.height)
                {
                    text2.text = text.Substring(text.IndexOf("\r\n") + 4);
                }
                else
                {
                    text2.text = text;
                }
            }
            else
            {
                timeAfterBoot += Time.deltaTime;
                if (timeAfterBoot > waitTimeAfterBoot)
                {
                    if (bootOver != null)
                    {
                        bootOver.Invoke();
                    }
                }
            }
        }
        else
        {
            counter += Time.deltaTime;
        }
    }
}