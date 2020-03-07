using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINodeHandler : MonoBehaviour
{
    [SerializeField] Dropdown _xAxis;
    [SerializeField] Dropdown _yAxis;
    [SerializeField] Dropdown _zAxis;
    [SerializeField] Dropdown _colors;
    [SerializeField] DataHandler _dataHandler;

    public void OnXAxisChange()
    {
        string typeName = _xAxis.options[_xAxis.value].text;
        _dataHandler.UpdateAxisType(DataHandler.Axis.X, typeName);
    }

    public void OnYAxisChange()
    {
        string typeName = _yAxis.options[_yAxis.value].text;
        _dataHandler.UpdateAxisType(DataHandler.Axis.Y, typeName);
    }

    public void OnZAxisChange()
    {
        string typeName = _zAxis.options[_zAxis.value].text;
        _dataHandler.UpdateAxisType(DataHandler.Axis.Z, typeName);
    }
}
