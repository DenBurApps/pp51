using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditProjects : EditWindowBase<Project>
{
    [SerializeField] InputFieldChanger nameInput;
    [SerializeField] InputFieldChanger startDateInput;
    [SerializeField] InputFieldChanger endDateInput;
    [SerializeField] InputFieldChanger descriptionInput;

    private bool activeProject;

    [SerializeField] Button activeButton;
    [SerializeField] Button completeButton;

    public override void Init(IPlateData<Project> plateData)
    {
        this.plateData = plateData;

        Project p = (plateData as ProjectPlateData).Properties; 
        nameInput.ChangeText(p.Name);    
        startDateInput.ChangeText(p.StartDate);
        endDateInput.ChangeText(p.EndDate);
        descriptionInput.ChangeText(p.Description);
        activeProject = p.Status;

        if(activeProject)
            completeButton.onClick.Invoke();
        else
            activeButton.onClick.Invoke();

    }

    public void Save()
    {
        Project properties = (plateData as ProjectPlateData).Properties;

        properties.Name = nameInput.text;
        properties.StartDate = startDateInput.text;
        properties.EndDate = endDateInput.text;
        properties.Description = descriptionInput.text;
        properties.Status = activeProject;

        DataProcessor.Instance.allData.Projects[properties.ID] = properties;
        DataProcessor.Instance.OnDataUpdate.Invoke();
        Parser.StartSave();
    }

    public void DeleteProject()
    {
        int i = 0;
        foreach(Project p in DataProcessor.Instance.allData.Projects)
        {

            if(p.ID == (plateData as ProjectPlateData).Properties.ID)
            {
                break;
            }
            i++;
        }
        DataProcessor.Instance.allData.Projects.RemoveAt(i);
        DataProcessor.Instance.OnDataUpdate.Invoke();
        Parser.StartSave();
    }
    public void ChangeProjectStatus(bool status)
    {
        activeProject = status;
    }
}
