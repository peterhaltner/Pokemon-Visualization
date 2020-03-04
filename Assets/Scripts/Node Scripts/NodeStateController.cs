using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeStateController : MonoBehaviour
{
    static Color SelectedColor = Color.red;
    static Color HoveredColor = Color.green;

    public enum State
    {
        Default,
        Selected,
        Hovered,
    }

    public State ActiveState { get { return _activeState; } }

    [SerializeField] NodeAppearance _appearance; 

    bool _isActive;
    State _activeState = State.Default;

    void Start()
    {
        SetDefault();
        SetActive(true);
    }


    public void SetState(State newState)
    {
        //If hovering but is selected, selected stays trumped
        if(newState == State.Hovered && _activeState == State.Selected)
        {
            return;
        }

        //Otherwise, we can set the state to be the new state
        switch (newState)
        {
            case State.Default:
                SetDefault();
                break;
            case State.Hovered:
                SetHovered();
                break;
            case State.Selected:
                SetSelected();
                break;
        }

        _activeState = newState;
    }

    public void SetActive(bool isActive)
    {
        _appearance.SetTransparent(!isActive);
        _isActive = isActive;
    }

    void SetDefault()
    {
        _appearance.SetLightActive(false);
    }

    void SetHovered()
    {
        _appearance.SetLightActive(true);
        _appearance.SetLightColor(HoveredColor);
    }

    void SetSelected()
    {
        _appearance.SetLightActive(true);
        _appearance.SetLightColor(SelectedColor);
    }
}
