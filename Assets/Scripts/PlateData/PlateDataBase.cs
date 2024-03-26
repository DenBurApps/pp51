using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlateDataBase<T> : MonoBehaviour, IPlateData<T>
{
    public T Properties;
    [SerializeField] private protected Button plateButton;
    protected SpawnManagerBase<T> spawnManager;
    public virtual void Init(T props, SpawnManagerBase<T> spawnManager)
    {
        this.spawnManager = spawnManager;
        plateButton.onClick.AddListener(() => spawnManager.OpenWindow(this));
    }
}
