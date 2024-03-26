using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private CategoryEditPlate CategoryEditPlate;
    [SerializeField] private GameObject choosed;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            CategoryEditPlate.ChangeCategoryColor(GetComponent<Image>().color,this);
        });
    }
    public void EnableButton()
    {
        choosed.SetActive(false);
    }
    public void DisableButton()
    {
        choosed.SetActive(true);
    }
}
