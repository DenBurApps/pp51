using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpensePlate : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI costTMP;

    public void Init(Color color,string Name,float cost)
    {
        image.color = color;
        nameTMP.text = Name;
        costTMP.text = "";
        if (cost < 0)
            costTMP.text += "-";
        else 
            costTMP.text += "+";
        costTMP.text += "$" + cost.ToString();
    }
}