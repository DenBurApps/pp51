using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InputFieldChanger : MonoBehaviour
{
    private TMP_InputField InputField;
    public string text;
    [SerializeField]
    private int MaxLength = 20;
    [SerializeField]
    private GameObject textObj;
    private void Awake()
    {
        InputField = GetComponent<TMP_InputField>();
        InputField.onSelect.AddListener((string t) => { OnSelect(); });
        InputField.onDeselect.AddListener((string t) => { OnDeselect(); });
    }
    private void OnSelect()
    {
        InputField.text = text;
    }
    private void OnDeselect()
    {
        text = InputField.text;
        if (InputField.text.Length > MaxLength) 
        {
            InputField.text = InputField.text.Truncate(MaxLength) + ".";
        }
        textObj.transform.localPosition = Vector3.zero;
    }

    public void ChangeText(string t)
    {
        text = t;
        InputField.text = t;
    }
}
