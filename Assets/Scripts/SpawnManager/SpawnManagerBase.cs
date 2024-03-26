using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnManagerBase<T> : MonoBehaviour
{
    private List<GameObject> spawnedPlates = new List<GameObject>();
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Transform spawnTransform { get { return GetComponent<Transform>(); } }
    protected List<T> list = new List<T>();

    [SerializeField] private protected GameObject EmptyObj;
    [SerializeField] private protected EditWindowBase<T> openWindow;

    protected virtual void Awake()
    {
        DataProcessor.Instance.OnDataUpdate += UpdateSpawnManager;
        UpdateSpawnManager();
    }
    private void OnEnable()
    {
        if (spawnedPlates.Count == 0)
            SpawnPlates();
    }
    protected virtual void OnDisable()
    {
        ClearSpawnedPlates();
        EmptyObj.SetActive(false);
    }
    private void SpawnPlates()
    {
        if (list.Count == 0)
            EmptyObj.SetActive(true);
        else
        {
            EmptyObj.SetActive(false);
            for (int i = 0; i < list.Count; i++)
            {
                var obj = Instantiate(spawnPrefab, spawnTransform);
                IPlateData<T> data = obj.GetComponent<IPlateData<T>>();

                data.Init(list[i],this);
                spawnedPlates.Add(obj);
            }
        }

    }
    private void ClearSpawnedPlates()
    {
        foreach(var obj in spawnedPlates)
            Destroy(obj);
        spawnedPlates.Clear();
    }

    protected virtual void UpdateSpawnManager() 
    {
        if (gameObject.activeSelf)
        {
            ClearSpawnedPlates();
            SpawnPlates();
        }
    }

    public void OpenWindow(PlateDataBase<T> plateData)
    {
        openWindow.gameObject.SetActive(true);
        openWindow.Init(plateData);
    }
}
