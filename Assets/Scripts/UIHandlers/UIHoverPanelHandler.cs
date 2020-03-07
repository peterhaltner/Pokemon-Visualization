using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHoverPanelHandler : MonoBehaviour
{
    [SerializeField] Text _hoverNameText;
    [SerializeField] GameObject _hoverPanel;

    public void UpdateHoverTextUI(GameObject pokemonNode)
    {
        if(pokemonNode.tag != "Pokemon")
        {
            Debug.LogError("This gameobject is not a Pokemon node");
            return;
        }

        var pokemonInfo = pokemonNode.GetComponent<NodeInformationController>();
        _hoverNameText.text = pokemonInfo.Name;
    }

    public void SetHoverUiActive(bool enabled)
    {
        _hoverPanel.SetActive(enabled);
    }
}
