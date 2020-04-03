using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSizeScaleController : MonoBehaviour
{
    [SerializeField] Slider _scaleSlider;
    [SerializeField] DataHandler _dataHandler;

    public void SizeScaleValueChanged()
    {
        _dataHandler.SetNodeScales(_scaleSlider.value);
    }
}
