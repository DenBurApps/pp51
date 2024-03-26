using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(DataProcessor))]
public class Parser : MonoBehaviour
{
    private string jsonPathNormal;

    private static Parser instance;
    private void Awake()
    {
        instance = this;

        jsonPathNormal = Application.persistentDataPath + "/obj.json";
        Debug.Log(jsonPathNormal);

        StartCoroutine(LoadAllData());
    }
    public IEnumerator LoadAllData()
    {
        var processor = GetComponent<DataProcessor>();
        DataStorage data;


        string jsonContent;
        if (File.Exists(jsonPathNormal))
        {
            jsonContent = File.ReadAllText(jsonPathNormal);
            data = JsonUtility.FromJson<DataStorage>(jsonContent);
        }
        else
        {
            data = new DataStorage();
        }

        yield return data;

        processor.LoadData(data);
    }
    public static void StartSave()
    {
        instance.StartCoroutine(instance.SaveAllData());
    }
    private IEnumerator SaveAllData()
    {
        var data = GetComponent<DataProcessor>().allData;
        var json = JsonUtility.ToJson(data);
        yield return json;
        try
        {
            File.WriteAllText(jsonPathNormal, json);

        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
