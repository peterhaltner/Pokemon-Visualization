using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSelectedTypeController : MonoBehaviour
{
    [SerializeField] GameObject _normalUiElement;
    [SerializeField] GameObject _poisonUiElement;
    [SerializeField] GameObject _psychicUiElement;
    [SerializeField] GameObject _grassUiElement;
    [SerializeField] GameObject _groundUiElement;
    [SerializeField] GameObject _iceUiElement;
    [SerializeField] GameObject _fireUiElement;
    [SerializeField] GameObject _rockUiElement;
    [SerializeField] GameObject _dragonUiElement;
    [SerializeField] GameObject _waterUiElement;
    [SerializeField] GameObject _bugUiElement;
    [SerializeField] GameObject _darkUiElement;
    [SerializeField] GameObject _fightingUiElement;
    [SerializeField] GameObject _ghostUiElement;
    [SerializeField] GameObject _steelUiElement;
    [SerializeField] GameObject _flyingUiElement;
    [SerializeField] GameObject _electricUiElement;
    [SerializeField] GameObject _fairyUiElement;

    //Ensure all are disabled at start
    void Start()
    {
        _normalUiElement.SetActive(false);
        _poisonUiElement.SetActive(false);
        _psychicUiElement.SetActive(false);
        _grassUiElement.SetActive(false);
        _groundUiElement.SetActive(false);
        _iceUiElement.SetActive(false);
        _fireUiElement.SetActive(false);
        _rockUiElement.SetActive(false);
        _dragonUiElement.SetActive(false);
        _waterUiElement.SetActive(false);
        _bugUiElement.SetActive(false);
        _darkUiElement.SetActive(false);
        _fightingUiElement.SetActive(false);
        _ghostUiElement.SetActive(false);
        _steelUiElement.SetActive(false);
        _flyingUiElement.SetActive(false);
        _electricUiElement.SetActive(false);
        _fairyUiElement.SetActive(false);
    }

    public void SetType(TypeHelper.Type type)
    {
        switch (type)
        {
            case TypeHelper.Type.Bug:
                _bugUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Dark:
                _darkUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Dragon:
                _dragonUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Electric:
                _electricUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Fairy:
                _fairyUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Fighting:
                _fightingUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Fire:
                _fireUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Flying:
                _flyingUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Ghost:
                _ghostUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Grass:
                _grassUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Ground:
                _groundUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Ice:
                _iceUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Normal:
                _normalUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Poison:
                _poisonUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Psychic:
                _psychicUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Rock:
                _rockUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Steel:
                _steelUiElement.SetActive(true);
                break;
            case TypeHelper.Type.Water:
                _waterUiElement.SetActive(true);
                break;
        }
    }
}
