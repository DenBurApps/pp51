using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditEmployee : EditWindowBase<Employee>, IEditWindow<Employee>
{
    [SerializeField] InputFieldChanger nameInput;
    [SerializeField] InputFieldChanger positionInput;
    [SerializeField] InputFieldChanger phoneNumberInput;
    [SerializeField] TMP_InputField hoursWorkedInput;
    [SerializeField] TMP_InputField rateOfPayInput;
    [SerializeField] TextMeshProUGUI salary;
    [SerializeField] InputFieldChanger descriptionInput;

    public void Save()
    {
        Employee employee = (plateData as EmployeePlateData).Properties;

        employee.Name = nameInput.text;
        employee.Position = positionInput.text;
        employee.PhoneNumber = phoneNumberInput.text;

        int.TryParse(hoursWorkedInput.text, out employee.Hours);
        float.TryParse(rateOfPayInput.text, out employee.RateOfPay);

        salary.text = employee.Salary.ToString();
        employee.Description = descriptionInput.text;

        DataProcessor.Instance.OnDataUpdate.Invoke();
        Parser.StartSave();
    }

    public override void Init(IPlateData<Employee> plateData)
    {
        base.Init(plateData);

        Employee employee = (plateData as EmployeePlateData).Properties;
        nameInput.ChangeText(employee.Name);
        positionInput.ChangeText(employee.Position);
        phoneNumberInput.ChangeText(employee.PhoneNumber);
        hoursWorkedInput.text = employee.Hours.ToString();
        rateOfPayInput.text = employee.RateOfPay.ToString();

        int.TryParse(hoursWorkedInput.text,out int a);
        int.TryParse(rateOfPayInput.text, out int b);
        salary.text = (a * b).ToString();

        descriptionInput.ChangeText(employee.Description);
    }

    public void DeleteEmployee()
    {
        int i = 0;
        foreach (Employee p in DataProcessor.Instance.allData.Employees)
        {

            if (p.ID == (plateData as EmployeePlateData).Properties.ID)
            {
                break;
            }
            i++;
        }
        DataProcessor.Instance.allData.Employees.RemoveAt(i);
        DataProcessor.Instance.OnDataUpdate.Invoke();
        Parser.StartSave();
    }

}
