using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EditWindowBase<T> : MonoBehaviour, IEditWindow<T>
{
    protected IPlateData<T> plateData;

    public virtual void Init(IPlateData<T> plateData)
    {
        this.plateData = plateData;
    }
}
