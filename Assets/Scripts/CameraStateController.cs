using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateController : MonoBehaviour
{
    [SerializeField] GameObject _perspectiveCamera;
    [SerializeField] GameObject _xyCamera;
    [SerializeField] GameObject _zyCamera;
    [SerializeField] GameObject _zxCamera;
    [SerializeField] CameraController _freeFlyCameraController;

    Dictionary<CameraTypes, GameObject> _cameraTypePairs = new Dictionary<CameraTypes, GameObject>();
    Vector3 _initialPerspectivePosition;
    Quaternion _initialPerspectiveRotation;

    public enum CameraTypes
    {
        FreeFlight,
        XYAxis,
        ZYAxis,
        ZXAxis,
    }

    CameraTypes _activeCameraType = CameraTypes.FreeFlight;

    void Start()
    {
        _cameraTypePairs.Add(CameraTypes.FreeFlight, _perspectiveCamera);
        _cameraTypePairs.Add(CameraTypes.XYAxis, _xyCamera);
        _cameraTypePairs.Add(CameraTypes.ZYAxis, _zyCamera);
        _cameraTypePairs.Add(CameraTypes.ZXAxis, _zxCamera);

        _initialPerspectivePosition = _perspectiveCamera.transform.position;
        _initialPerspectiveRotation = _perspectiveCamera.transform.rotation;
    }

    public void ResetPerspectiveCamera()
    {
        _perspectiveCamera.transform.SetPositionAndRotation(
            _initialPerspectivePosition,
            _initialPerspectiveRotation
        );

        _freeFlyCameraController.ResetPitchAndYaw();
    }

    public void SetCameraType(CameraTypes newCameraType)
    {
        //Disable all cameras besides the active one
        foreach(var cameraPair in _cameraTypePairs)
        {
            cameraPair.Value.SetActive(cameraPair.Key == newCameraType);
        }

        _activeCameraType = newCameraType;

        //Keep perspective camera in same location as active camera
        if(_activeCameraType != CameraTypes.FreeFlight)
        {
            Transform activeTransform = _cameraTypePairs[_activeCameraType].transform;

            _perspectiveCamera.transform.SetPositionAndRotation(
                activeTransform.position,
                activeTransform.rotation
            );
        }

        _freeFlyCameraController.SetMovementActive(_activeCameraType == CameraTypes.FreeFlight);
    }
}
