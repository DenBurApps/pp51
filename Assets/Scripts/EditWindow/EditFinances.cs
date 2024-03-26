using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditFinances : EditWindowBase<Project>
{
    private List<CategoryPlate> categories = new List<CategoryPlate>();
    private List<ExpensePlate> expenses = new List<ExpensePlate>();
    private List<GameObject> dates = new List<GameObject>();

    [SerializeField] private PieChart graphic;

    [SerializeField] private Button changeButton;

    [SerializeField] private CategoryPlate categoryPrefab;
    [SerializeField] private ExpensePlate expensePrefab;

    [SerializeField] private Transform categorySpawnPlace;
    [SerializeField] private Transform expenseSpawnPlace;
    [SerializeField] private GameObject dateHolderPrefab;
    [SerializeField] private Button ChangeButton;
    [SerializeField] private CategoriesEditWindow categoriesEditWindow;
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI datesTMP;
    [SerializeField] private TextMeshProUGUI totalExpensesTMP;

    private void Awake()
    {
        ChangeButton.onClick.AddListener(InitCategoriesEditWindow);
    }
    private void InitCategoriesEditWindow()
    {
        categoriesEditWindow.gameObject.SetActive(true);
        categoriesEditWindow.Init((plateData as FinansePlateData).Properties);
    }
    public override void Init(IPlateData<Project> plateData)
    {
        this.plateData = plateData;
        var props = (plateData as FinansePlateData).Properties;
        graphic.Init(props.Categories);
        SpawnCategoryPlates();
        SpawnExpensePlates();

        datesTMP.text = TextChanger.Truncate(props.StartDate,10) + "-" + TextChanger.Truncate(props.EndDate,10);
        totalExpensesTMP.text = "$" + props.TotalExpenses;
    }
    public void UpdateThisWindow()
    {
        Init(plateData);
    }
    public void DeleteProject()
    {
        int i = 0;
        foreach (Project p in DataProcessor.Instance.allData.Projects)
        {

            if (p.ID == (plateData as FinansePlateData).Properties.ID)
            {
                break;
            }
            i++;
        }
        DataProcessor.Instance.allData.Projects.RemoveAt(i);
        DataProcessor.Instance.OnDataUpdate.Invoke();
        Parser.StartSave();
    }

    private void SpawnCategoryPlates()
    {
        ClearCategoryPlate();
        foreach(var item in (plateData as FinansePlateData).Properties.Categories)
        {
            var obj = Instantiate(categoryPrefab, categorySpawnPlace);
            categories.Add(obj);
            Color color;
            ColorUtility.TryParseHtmlString(item.Color, out color);
            obj.Init(color, item.Name);
        }
    }


    private void SpawnExpensePlates()
    {
        ClearExpensePlates();

        List<string> keys = new List<string>();
        var props = (plateData as FinansePlateData).Properties.expenseOnDate;
        foreach (var item in props)
        {
            keys.Add(item.Key);
        }
        for (int i = keys.Count - 1; i >= 0; i--)
        {
            var obj = Instantiate(dateHolderPrefab, expenseSpawnPlace);
            dates.Add(obj);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = keys[i];
            for(int j = props[keys[i]].Count - 1; j >= 0;j--)
            {
                var item = Instantiate(expensePrefab, obj.transform);

                Color color;
                ColorUtility.TryParseHtmlString(props[keys[i]][j].CategoryColor, out color);

                item.Init(color, props[keys[i]][j].CategoryName, props[keys[i]][j].ExpenseCount);
            }
        }
    }
    public void SpawnExpensePlates(DateTime startDate,DateTime endDate)
    {
        ClearExpensePlates();

        List<string> keys = new List<string>();
        var props = (plateData as FinansePlateData).Properties.expenseOnDate;
        foreach (var key in props.Keys)
        {
            DateTime dt = ConvertString(key);
            if (dt >= startDate && dt <= endDate)
            keys.Add(key);
        }
        for (int i = keys.Count - 1; i >= 0; i--)
        {
            var obj = Instantiate(dateHolderPrefab, expenseSpawnPlace);
            dates.Add(obj);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = keys[i];
            for (int j = props[keys[i]].Count - 1; j >= 0; j--)
            {
                var item = Instantiate(expensePrefab, obj.transform);

                Color color;
                ColorUtility.TryParseHtmlString(props[keys[i]][j].CategoryColor, out color);

                item.Init(color, props[keys[i]][j].CategoryName, props[keys[i]][j].ExpenseCount);
            }
        }

        DateTime ConvertString(string s)
        {
            DateTime.TryParse(s, out DateTime dt);
            return dt;
        }
    }
    private void ClearCategoryPlate()
    {
        foreach (var category in categories)
        {
            Destroy(category.gameObject);
        }
        categories.Clear();
    }
    private void ClearExpensePlates()
    {
        foreach (var date in dates)
        {
            Destroy(date);
        }
        expenses.Clear();
        dates.Clear();
    }
}
