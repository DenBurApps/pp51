using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Project;

public class PieChart : MonoBehaviour
{
    private List<Image> images = new List<Image>();
    private List<Category> values;

    [SerializeField] private Image prefab;
    [SerializeField] private Transform spawnPlace;
    public void Init(List<Category> values)
    {
        foreach(var obj in images)
        {
            Destroy(obj.GetComponent<GameObject>());
        }
        images.Clear();

        this.values = values;

        foreach (var item in values)
        {
            var obj = Instantiate(prefab, spawnPlace);
            ColorUtility.TryParseHtmlString(item.Color, out Color color);
            obj.color = color;
            images.Add(obj);
        }

        SetValues();
    }
    private void SetValues()
    {
        float totalValues = 0;
        string str = "";
        for (int i = values.Count - 1; i > 0; i--)
        {
            totalValues += FindPercentage(i);
            str += totalValues.ToString() + "\n";
            images[i].fillAmount = totalValues;
        }
    }

    private float FindPercentage(int i)
    {
        float total = 0;
        for(int j = 0; j < values.Count; j++)
        {
            total += values[j].Expenses;
        }
        return values[i].Expenses / total;
    }
}
