using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFilterHandler : MonoBehaviour
{
    [SerializeField] Text _filterAmountStatus;

    [SerializeField] Button _searchClearButton;
    [SerializeField] InputField _searchField;

    //TODO: Continue here with Filtering

    [SerializeField] DataHandler _dataHandler;
    [SerializeField] FilterHandler _filterHandler;

    void Start()
    {
        UpdateFilterAmountStatus();
    }

    public void SearchClearClicked()
    {
        _searchClearButton.gameObject.SetActive(false);
        _searchField.text = "";
        _filterHandler.SetNameFilter("");
        UpdateFilterAmountStatus();
    }

    public void SearchInputChanged()
    {
        string input = _searchField.text;

        _searchClearButton.gameObject.SetActive(input != "");
        _filterHandler.SetNameFilter(input);
        UpdateFilterAmountStatus();
    }

    //To get called after filter changes
    void UpdateFilterAmountStatus()
    {
        _filterAmountStatus.text = "Displaying "
            + _filterHandler.NumberPokemonFilterMatched 
            + "/"
            + _dataHandler.NumberOfPokemon
            + " Pokémon";
    }
}
