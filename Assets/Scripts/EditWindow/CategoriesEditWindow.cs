using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CategoriesEditWindow : MonoBehaviour
{
    private List<CategoryEditPlate> plates = new List<CategoryEditPlate>();
    private Project project;

    [SerializeField] private TextMeshProUGUI totalExpensesTMP;

    [SerializeField] private CategoryEditPlate prefab;
    [SerializeField] private Transform spawnPlace;
    [SerializeField] private Transform addNewTransform;

    public void Init(Project project)
    {
        this.project = project;
        totalExpensesTMP.text = project.TotalExpenses + "$";
        SpawnPlates();
        addNewTransform.SetAsLastSibling();
    }

    private void SpawnPlates()
    {
        ClearPlates();
        for (int i = 0; i < project.Categories.Count; i++)
        {
            var obj = Instantiate(prefab, spawnPlace);
            obj.Init(project.Categories[i], project.ID, i);
            plates.Add(obj);
        }
    }
    private void ClearPlates()
    {
        foreach (var obj in plates)
            Destroy(obj.gameObject);
        plates.Clear();
    }
    public void Save()
    {
        foreach (var obj in plates)
            obj.Save();
        Parser.StartSave();
    }
    public void AddNewCategory()
    {
        project.Categories.Add(new Category("New Category", "#FFFFFF"));
        var obj = Instantiate(prefab, spawnPlace);
        obj.Init(project.Categories[project.Categories.Count - 1], project.ID, project.Categories.Count - 1);
        addNewTransform.SetAsLastSibling();
    }
}
