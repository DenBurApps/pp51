using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateNewEmployee : MonoBehaviour
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
        Employee employee = new Employee();

        employee.Name = nameInput.text;
        employee.Position = positionInput.text;
        employee.PhoneNumber = phoneNumberInput.text;

        int.TryParse(hoursWorkedInput.text, out employee.Hours);
        float.TryParse(rateOfPayInput.text, out employee.RateOfPay);

        salary.text = employee.Salary.ToString();
        employee.Description = descriptionInput.text;

        DataProcessor.Instance.AddNewEmployee(employee);

    }
}
