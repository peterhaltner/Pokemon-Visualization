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

    public void OnColorsChange()
    {
        string materialName = _colors.options[_colors.value].text;

        switch (materialName)
        {
            case "Types":
                _dataHandler.SetMaterialType(MaterialHelper.MaterialType.Type);
                break;
            case "Generation":
                _dataHandler.SetMaterialType(MaterialHelper.MaterialType.Generation);
                break;
            default:
                Debug.LogErrorFormat("Material name '{0}' not found", materialName);
                break;
        }
    }
}
