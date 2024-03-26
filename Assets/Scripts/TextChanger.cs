using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class TextChanger
{
    public static string Truncate(string text,int maxLength = 20)
    {
        if(text.Length > maxLength) 
            return text.Truncate(maxLength) + "...";

        return text;
    }
}
