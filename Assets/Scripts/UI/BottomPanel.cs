using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
    public static BottomPanel instance;

    [SerializeField] private Color disabledColor;

    [Serializable]
    private struct buttonsAndWindows
    {
        public Button button;
        public Image image;
        public GameObject window;
    }
    [SerializeField]
    private buttonsAndWindows[] BAW;
    private void Awake()
    {
        instance = this;
        foreach (var obj in BAW)
        {
            obj.button.onClick.AddListener(() =>
            OnClick(obj.image, obj.button, obj.window));
        }
    }
    private void OnClick(Image activate, Button button, GameObject window)
    {
        foreach(var obj in BAW)
        {
            obj.button.interactable = true;
            obj.image.color = disabledColor;
            obj.window.SetActive(false);
        }
        window.SetActive(true);
        activate.color = Color.white;
        button.interactable = false;
    }
}
