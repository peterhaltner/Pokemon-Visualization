using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControlPanelHandler : MonoBehaviour
{
    [SerializeField] Button _collapseButton;

    Vector2 _collapsedPositon = new Vector2(200f, 0);
    Vector2 _expandedPositon = new Vector2(-200f, 0);
    const float AnimationTime = 0.2f;

    bool isExpanded = true;
    float _timeRemaining;
    RectTransform _collapsePanel;
    Text _collapseButtonArrowText;


    void Start()
    {
        _collapsePanel = GetComponent<RectTransform>();
        _collapseButtonArrowText = _collapseButton.GetComponentInChildren<Text>();
    }

    public void CollapseControlPanelClicked()
    {
        _timeRemaining = AnimationTime;
        if(isExpanded)
        {
            StartCoroutine(StartCollapseAnimation());
            isExpanded = false;
        }
        else
        {
            StartCoroutine(StartExpandAnimation());
            isExpanded = true;
        }

        _collapseButton.interactable = false;
    }

    public IEnumerator StartCollapseAnimation()
    {
        while(_timeRemaining > 0)
        {
            _collapsePanel.anchoredPosition = Vector2.Lerp(
                _expandedPositon, _collapsedPositon, 1 - _timeRemaining / AnimationTime
            );

            _timeRemaining -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _collapsePanel.anchoredPosition = _collapsedPositon;
        _collapseButton.interactable = true;
        _collapseButtonArrowText.text = "<";
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
        _collapseButtonArrowText.text = ">";
    }
}
