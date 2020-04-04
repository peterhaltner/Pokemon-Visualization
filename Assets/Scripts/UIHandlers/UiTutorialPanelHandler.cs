using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTutorialPanelHandler : MonoBehaviour
{
    [SerializeField] GameObject _overlay;
    [SerializeField] DataHandler _dataHandler;

    public void OnReadyClicked()
    {
        _overlay.SetActive(false);
        gameObject.SetActive(false);
        _dataHandler.SetupNodes();
    }
}
