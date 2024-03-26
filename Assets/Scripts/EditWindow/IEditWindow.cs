using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEditWindow<T>
{
    public void Init(IPlateData<T> plateData);
}
