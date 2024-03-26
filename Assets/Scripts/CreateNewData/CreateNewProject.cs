using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewProject : MonoBehaviour
{
    [SerializeField] InputFieldChanger nameInput;
    [SerializeField] InputFieldChanger startDateInput;
    [SerializeField] InputFieldChanger endDateInput;
    [SerializeField] InputFieldChanger descriptionInput;
    [SerializeField] InputFieldChanger ExpenditureInput;
    [SerializeField] InputFieldChanger rentInput;
    [SerializeField] InputFieldChanger otherInput;

    private bool activeProject;

    public void ChangeProjectState(bool state)
    {
        activeProject = state;
    }
    public void Save()
    {
        Project project = new Project();

        project.Name = nameInput.text;
        project.StartDate = startDateInput.text;
        project.EndDate = endDateInput.text;
        project.Description = descriptionInput.text;
        project.Status = activeProject;

        DataProcessor.Instance.AddNewProject(project);

        CreateCategory("Expenditure", "#FFFFFF", ExpenditureInput.text);
        CreateCategory("Rent", "#E1FD02", rentInput.text);
        CreateCategory("Other", "#9747FF", otherInput.text);


        void CreateCategory(string name, string color, string value)
        {
            project.Categories.Add(new Category(name, color));
            float.TryParse(value, out float exp);

            string date = DateTime.Today.ToString().Remove(10);
            var newExp = new Expense(exp, date, project.Categories[project.Categories.Count - 1]);

            DataProcessor.Instance.AddNewExpense(project.ID, project.Categories.Count - 1, newExp);
        }
    }


}
