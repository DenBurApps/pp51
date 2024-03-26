using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmployeePlateData : PlateDataBase<Employee>, IPlateData<Employee>
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI positionTMP;

    public override void Init(Employee props, SpawnManagerBase<Employee> spawnManager)
    {
        base.Init(props, spawnManager);
        Properties = props;
        nameTMP.text = TextChanger.Truncate(props.Name,20);
        positionTMP.text = TextChanger.Truncate(props.Position,20);
    }
}
