using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiOptionsPanelHandler : MonoBehaviour
{
    [SerializeField] Button _collapseButton;

    Vector2 _collapsedPositon = new Vector2(200f, -200f);
    Vector2 _expandedPositon = new Vector2(200f, 200f);
    const float AnimationTime = 0.2f;

    bool _isExpanded = true;
    float _timeRemaining;
    RectTransform _collapsePanel;
    Text _collapseButtonArrowText;

    void Start()
    {
        _collapsePanel = GetComponent<RectTransform>();
        _collapseButtonArrowText = _collapseButton.GetComponentInChildren<Text>();
    }

    public void CollapseOptionsPanelClicked()
    {
        _timeRemaining = AnimationTime;
        if (_isExpanded)
        {
            StartCoroutine(StartCollapseAnimation());
            _isExpanded = false;
        }
        else
        {
            StartCoroutine(StartExpandAnimation());
            _isExpanded = true;
        }

        _collapseButton.interactable = false;
    }

    public void ExitApplicationButtonPressed()
    {
        Application.Quit();
    }

    public IEnumerator StartCollapseAnimation()
    {
        while (_timeRemaining > 0)
        {
            _collapsePanel.anchoredPosition = Vector2.Lerp(
                _expandedPositon, _collapsedPositon, 1 - _timeRemaining / AnimationTime
            );

            _timeRemaining -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _collapsePanel.anchoredPosition = _collapsedPositon;
        _collapseButton.interactable = true;
        _collapseButtonArrowText.text = "ʌ";
    }

    public IEnumerator StartExpandAnimation()
    {
        while (_timeRemaining > 0)
        {
            _collapsePanel.anchoredPosition = Vector2.Lerp(
                _collapsedPositon, _expandedPositon, 1 - _timeRemaining / AnimationTime
            );

            _timeRemaining -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _collapsePanel.anchoredPosition = _expandedPositon;
        _collapseButton.interactable = true;
        _collapseButtonArrowText.text = "v";
    }
}
