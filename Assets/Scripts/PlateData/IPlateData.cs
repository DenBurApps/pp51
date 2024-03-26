using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlateData<T>
{
    public void Init(T props, SpawnManagerBase<T> spawnManager);
}
