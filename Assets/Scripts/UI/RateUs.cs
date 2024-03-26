using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RateUs : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;
    private void Awake()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => { OnStarButtonClick(button);});
        }
    }
    [SerializeField] private Sprite disabledObj;
    [SerializeField] private Sprite enabledObj;

    private void OnStarButtonClick(Button clickedButton)
    {
        foreach (var button in buttons)
        {
            button.gameObject.GetComponent<Image>().sprite = disabledObj;
        }
        foreach (var button in buttons)
        {
            button.gameObject.GetComponent<Image>().sprite = enabledObj;
            if (button == clickedButton)
            {
                break;
            }
        }
    }
}
