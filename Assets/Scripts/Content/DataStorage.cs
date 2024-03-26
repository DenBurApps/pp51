using System;
using System.Collections.Generic;

[Serializable]
public class DataStorage
{
    public List<Project> Projects = new List<Project>();
    public List<Employee> Employees = new List<Employee>();

}
[Serializable]
public class Project
{
    public string Name;

    public int ID;

    public string StartDate;
    public string EndDate;

    public string Description;
    public bool Status;

    public List<Category> Categories = new List<Category>();

    public Dictionary<string, List<Expense>> expenseOnDate = new Dictionary<string, List<Expense>>();

    private float totalExpenses;

    public float TotalExpenses
    {
        get
        {
            totalExpenses = 0;
            foreach (var obj in Categories)
            {
                totalExpenses += obj.Expenses;
            };
            return totalExpenses;
        }
        set { }
    }
    

}
[Serializable]
public class Category
{
    public string Name;
    public string Color;

    public List<Expense> ExpensesList = new List<Expense>();

    private float expenses;
    public float Expenses
    {
        get
        {
            expenses = 0;
            foreach (var obj in ExpensesList)
            {
                expenses += obj.ExpenseCount;
            };
            return expenses;
        }
        set { }
    }

    public Category(string name, string color)
    {
        Name = name;
        Color = color;
    }

}
[Serializable]
public class Expense
{
    public float ExpenseCount;
    public string Date;

    public string CategoryName;
    public string CategoryColor;

    public Expense(float expense, string date, Category categoryLink)
    {
        ExpenseCount = expense;
        Date = date;
        CategoryName = categoryLink.Name;
        CategoryColor = categoryLink.Color;

    }
}
[Serializable]
public class Employee
{
    public string Name;
    public string PhotoLink;
    public string Position;
    public string PhoneNumber;
    public int Hours;
    public float RateOfPay;
    private float salary;
    public float Salary { get 
        { 
            salary = 0;

            salary = Hours * RateOfPay;
            return salary;
        } 
        set { } }
    public string Description;

    public int ID;

}