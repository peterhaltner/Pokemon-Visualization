using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectedPanelHandler : MonoBehaviour
{
    [SerializeField] Text _pokemonName;
    [SerializeField] UiSelectedTypeController _type1Controller;
    [SerializeField] UiSelectedTypeController _type2Controller;
    [SerializeField] Text _pokemonHP;
    [SerializeField] Text _pokemonAttack;
    [SerializeField] Text _pokemonDefense;
    [SerializeField] Text _pokemonSpecialAttack;
    [SerializeField] Text _pokemonSpecialDefense;
    [SerializeField] Text _pokemonSpeed;
    [SerializeField] Text _pokemonGeneration;
    [SerializeField] Text _pokemonLegendary;
    [SerializeField] GameObject _selectedPanel;

    public void UpdateSelectedTextUI(GameObject pokemonNode)
    {
        if (pokemonNode.tag != "Pokemon")
        {
            Debug.LogError("This gameobject is not a Pokemon node");
            return;
        }

        var pokemonInfo = pokemonNode.GetComponent<NodeInformationController>();

        _pokemonName.text = pokemonInfo.Name;

        _type1Controller.SetType(pokemonInfo.Type1);
        _type2Controller.SetType(pokemonInfo.Type2);

        _pokemonHP.text = pokemonInfo.HP.ToString();
        _pokemonAttack.text = pokemonInfo.Attack.ToString();
        _pokemonDefense.text = pokemonInfo.Defense.ToString();
        _pokemonSpecialAttack.text = pokemonInfo.SpecialAttack.ToString();
        _pokemonSpecialDefense.text = pokemonInfo.SpecialDefense.ToString();
        _pokemonSpeed.text = pokemonInfo.Speed.ToString();
        _pokemonGeneration.text = pokemonInfo.Generation.ToString();
        _pokemonLegendary.text = pokemonInfo.IsLegendary.ToString();
    }

    public void SetSelectedUiActive(bool enabled)
    {
        _selectedPanel.SetActive(enabled);
    }
}
