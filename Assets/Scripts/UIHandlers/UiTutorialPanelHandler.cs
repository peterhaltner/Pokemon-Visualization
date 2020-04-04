using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTutorialPanelHandler : MonoBehaviour
{
    [SerializeField] GameObject _overlay;

    public void OnReadyClicked()
    {
        _overlay.SetActive(false);
        gameObject.SetActive(false);
    }
}
