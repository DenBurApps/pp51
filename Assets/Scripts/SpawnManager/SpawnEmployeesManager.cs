using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmployeesManager : SpawnManagerBase<Employee>
{
    protected override void UpdateSpawnManager()
    {
        list = DataProcessor.Instance.allData.Employees;
        base.UpdateSpawnManager();
    }
}
