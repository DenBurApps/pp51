using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectPlateData : PlateDataBase<Project>, IPlateData<Project>
{
    [SerializeField] private Image plateImage;

    [SerializeField] private Color[] textColors;
    private static int colorNumber;
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI dateTMP;
    [SerializeField] private TextMeshProUGUI descriptionTMP;
    [SerializeField] private TextMeshProUGUI statusTMP;

    private void OnDisable()
    {
        colorNumber = 0;
    }
    public override void Init(Project props, SpawnManagerBase<Project> spawnManager)
    {
        base.Init(props, spawnManager);
        Properties = props;
        plateImage.color = (spawnManager as SpawnProjectsManager).SetPlateColor();

        { 
            if(colorNumber == textColors.Length)
                colorNumber = 0;

            nameTMP.color = textColors[colorNumber];
            dateTMP.color = textColors[colorNumber];
            descriptionTMP.color = textColors[colorNumber];
            statusTMP.color = textColors[colorNumber];

            colorNumber++;
        }

        nameTMP.text = TextChanger.Truncate(Properties.Name,25);
        dateTMP.text = TextChanger.Truncate(Properties.EndDate,10);
        descriptionTMP.text = TextChanger.Truncate(Properties.Description,25);
        statusTMP.text = Properties.Status ? "Complete" : "Active";

    }
}
