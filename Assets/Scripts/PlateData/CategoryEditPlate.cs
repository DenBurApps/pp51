using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryEditPlate : MonoBehaviour
{
    private Category category;
    private int projectID;
    private int categoryID;

    [SerializeField] private TextMeshProUGUI expensesAmount;

    [SerializeField] private InputFieldChanger nameField;
    [SerializeField] private InputFieldChanger newExpenseField;
    [SerializeField] private Image imageWithColor;

    [SerializeField] private ColorButton[] colorButtons;
    public void Init(Category category,int projectID,int CategoryID)
    {
        this.category = category;
        this.projectID = projectID;
        this.categoryID = CategoryID;
        nameField.ChangeText(category.Name);
        expensesAmount.text = category.Expenses.ToString();
        Color color;
        ColorUtility.TryParseHtmlString(category.Color, out color);
        imageWithColor.color = color;

        foreach (var item in colorButtons)
        {
            if (item.GetComponent<Image>().color == color)
            {
                item.DisableButton();
                break;
            }
        }
    }
    public void Save()
    {
        category.Name = nameField.text;
        if (newExpenseField.text != "")
        {
            float.TryParse(newExpenseField.text, out float exp);
            string date = DateTime.Today.ToString().Remove(10);

            var newExp = new Expense(exp, date, DataProcessor.Instance.allData.Projects[projectID].Categories[categoryID]);

            DataProcessor.Instance.AddNewExpense(projectID, categoryID, newExp);
        }
        category.Color = "#" + ColorUtility.ToHtmlStringRGB(imageWithColor.color);
        foreach(var item in category.ExpensesList)
        {
            item.CategoryColor = category.Color;
            item.CategoryName = category.Name;
        }
    }
    public void ChangeCategoryColor(Color color, ColorButton colorButton)
    {
        imageWithColor.color = color;
        foreach(var item in colorButtons)
        {
            if (item != colorButton)
                item.EnableButton();
        }
        colorButton.DisableButton();
    }
}
