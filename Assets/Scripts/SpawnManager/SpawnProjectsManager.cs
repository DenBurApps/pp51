using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnProjectsManager : SpawnManagerBase<Project>
{
    [SerializeField] private Color[] PlateColors;
    private int lastChoosedColor;

    protected override void UpdateSpawnManager()
    {
        lastChoosedColor = 0;
        list = DataProcessor.Instance.allData.Projects;
        base.UpdateSpawnManager();
    }
    public Color SetPlateColor()
    {
        if (lastChoosedColor == PlateColors.Length)
            lastChoosedColor = 0;
        return PlateColors[lastChoosedColor++];
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        lastChoosedColor = 0;
    }
}
