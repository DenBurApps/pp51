using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinansePlateData : PlateDataBase<Project>, IPlateData<Project>
{
    [SerializeField] private Image plateImage;

    [SerializeField] private Color[] textColors;
    private static int colorNumber;
    [SerializeField] private PieChart graphic;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI dateTMP;
    [SerializeField] private TextMeshProUGUI statusTMP;
    [SerializeField] private TextMeshProUGUI ExpenseTMP;

    


    private void OnDisable()
    {
        colorNumber = 0;
    }
    public override void Init(Project props, SpawnManagerBase<Project> spawnManager)
    {
        base.Init(props, spawnManager);
        Properties = props;
        plateImage.color = (spawnManager as SpawnFinansesManager).SetPlateColor();

        graphic.Init(props.Categories);

        { 
            if(colorNumber == textColors.Length)
                colorNumber = 0;

            nameTMP.color = textColors[colorNumber];
            dateTMP.color = textColors[colorNumber];
            statusTMP.color = textColors[colorNumber];

            colorNumber++;
        }

        nameTMP.text = TextChanger.Truncate(Properties.Name, 40);
        dateTMP.text = Properties.EndDate;
        statusTMP.text = Properties.Status ? "Complete" : "Active";
        ExpenseTMP.text = Properties.TotalExpenses.ToString();

    }
}
