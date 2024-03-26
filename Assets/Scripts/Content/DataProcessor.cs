using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Parser))]
public class DataProcessor : MonoBehaviour
{
    public static DataProcessor Instance;
    public DataStorage allData;
    public Action OnDataUpdate;

    private void Awake()
    {
        Instance = this;
    }

    public void AddNewProject(Project project)
    {
        project.ID = allData.Projects.Count;
        allData.Projects.Add(project);
        OnDataUpdate.Invoke();

        Parser.StartSave();
    }
    public void AddNewEmployee(Employee employee)
    {
        employee.ID = allData.Employees.Count;
        allData.Employees.Add(employee);
        OnDataUpdate.Invoke();

        Parser.StartSave();
    }
    public void AddNewExpense(int projectID,int categoryID,Expense expense)
    {
        var project = allData.Projects[projectID];
        project.Categories[categoryID].ExpensesList.Add(expense);

        if (project.expenseOnDate.ContainsKey(expense.Date))
            project.expenseOnDate[expense.Date].Add(expense);

        else
        {
            project.expenseOnDate.Add(expense.Date, new List<Expense>());
            project.expenseOnDate[expense.Date].Add(expense);
        }
        Parser.StartSave();

    }
    private void FillExpenseOnDate()
    {
        foreach(Project project in allData.Projects)
        {
            foreach(var category in project.Categories)
            {
                foreach(var expense in category.ExpensesList)
                {
                    if (!project.expenseOnDate.ContainsKey(expense.Date))
                    {
                        project.expenseOnDate.Add(expense.Date, new List<Expense>());
                        project.expenseOnDate[expense.Date].Add(expense);
                    }
                    else
                    {
                        project.expenseOnDate[expense.Date].Add(expense);
                    }
                }
            }

        }
    }


    public void LoadData(DataStorage data)
    {
        allData = data;

        FillExpenseOnDate();
    }
}
