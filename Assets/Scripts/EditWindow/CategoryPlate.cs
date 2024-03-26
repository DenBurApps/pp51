using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPlate: MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI nameTMP;

    public void Init(Color color,string text)
    {
        image.color = color;
        nameTMP.text = text;
    }
}