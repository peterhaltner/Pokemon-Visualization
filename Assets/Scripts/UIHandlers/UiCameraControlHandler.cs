using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCameraControlHandler : MonoBehaviour
{
    [SerializeField] Dropdown _cameraViewDropdown;
    [SerializeField] Button _resetCameraButton;
    [SerializeField] CameraStateController _cameraStateController;

    /* Camera View Dropdown Values
     * 0 - Free Flight
     * 1 - XY Axis
     * 2 - ZY Axis
     * 3 - ZX Axis
     */
    public void CameraViewDropdownChanged()
    {
        int val = _cameraViewDropdown.value;

        switch (val)
        {
            case 0:
                _cameraStateController.SetCameraType(CameraStateController.CameraTypes.FreeFlight);
                break;
            case 1:
                _cameraStateController.SetCameraType(CameraStateController.CameraTypes.XYAxis);
                break;
            case 2:
                _cameraStateController.SetCameraType(CameraStateController.CameraTypes.ZYAxis);
                break;
            case 3:
                _cameraStateController.SetCameraType(CameraStateController.CameraTypes.ZXAxis);
                break;
            default:
                Debug.LogErrorFormat("Case is not covered '{0}'",val);
                break;
        }

        //Only show reset when Free Flight is selected
        _resetCameraButton.gameObject.SetActive(val == 0);
    }

    public void ResetCameraPressed()
    {
        _cameraStateController.ResetPerspectiveCamera();
    }
}
