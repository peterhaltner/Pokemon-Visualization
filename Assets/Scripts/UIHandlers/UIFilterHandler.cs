using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFilterHandler : MonoBehaviour
{
    [SerializeField] Text _filterAmountStatus;

    //Search Filter UI Elements
    [SerializeField] Button _searchClearButton;
    [SerializeField] InputField _searchField;

    //Type Filter UI Elements
    [SerializeField] List<Toggle> _typeToggles;
    [SerializeField] Dropdown _typeFilterTypeDropdown;
    [SerializeField] Button _selectAllTypesButton;
    [SerializeField] Button _unselectAllTypesButton;
    [SerializeField] Button _typeClearButton;

    [SerializeField] DataHandler _dataHandler;
    [SerializeField] FilterHandler _filterHandler;

    Dictionary<string, Toggle> _toggleNamePairs = new Dictionary<string, Toggle>();

    void Start()
    {
        UpdateFilterAmountStatus();

        foreach(Toggle toggle in _typeToggles)
        {
            _toggleNamePairs.Add(toggle.transform.parent.name, toggle);
        }
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

    public void FilterClearClicked()
    {
        FilterSelectAllClicked();

        _typeFilterTypeDropdown.value = 0;
        FilterTypeDropdownChanged();

        _typeClearButton.gameObject.SetActive(false);
    }

    public void FilterSelectAllClicked()
    {
        foreach(Toggle toggle in _typeToggles)
        {
            if(!toggle.isOn)
            {
                toggle.isOn = true;
                FilterPokemonToggled(toggle.transform.parent.name);
            }
        }

        _unselectAllTypesButton.interactable = true;
        _selectAllTypesButton.interactable = false;

        UpdateTypeClearButtonVisiblity();
        _unselectAllTypesButton.interactable = true;
        _selectAllTypesButton.interactable = false;
    }

    public void FilterUnselectAllClicked()
    {
        foreach (Toggle toggle in _typeToggles)
        {
            if (toggle.isOn)
            {
                toggle.isOn = false;
                FilterPokemonToggled(toggle.transform.parent.name);
            }
        }

        UpdateTypeClearButtonVisiblity();
        _unselectAllTypesButton.interactable = false;
        _selectAllTypesButton.interactable = true;
    }

    public void FilterPokemonToggled(string typeName)
    {
        var selectedType = TypeHelper.ParseType(typeName);

        //TODO: Weird error where this function gets called when cleaning up
        if(_toggleNamePairs.Count == 0)
        {
            return;
        }

        Toggle typeToggle = _toggleNamePairs[typeName];

        if (typeToggle.isOn)
        {
            _filterHandler.AddTypeFilter(selectedType);
        }
        else
        {
            _filterHandler.RemoveTypeFilter(selectedType);
        }

        UpdateTypeSelectAllButtonVisibility();
        UpdateTypeUnselectAllButtonVisibility();
        UpdateTypeClearButtonVisiblity();
        UpdateFilterAmountStatus();
    }

    public void FilterTypeDropdownChanged()
    {
        int option = _typeFilterTypeDropdown.value;

        //Match Any
        if(option == 0)
        {
            _filterHandler.SetTypeFilters(FilterHandler.FilterType.CanMatchAny);
        }
        //Must Match All
        else
        {
            _filterHandler.SetTypeFilters(FilterHandler.FilterType.MustMatchAll);
        }

        UpdateTypeClearButtonVisiblity();
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

    //Disable Clear button if using default values
    void UpdateTypeClearButtonVisiblity()
    {
        bool isDefaultValues = true;

        foreach(var toggle in _typeToggles)
        {
            if(!toggle.isOn)
            {
                isDefaultValues = false;
                break;
            }
        }

        if(_typeFilterTypeDropdown.value != 0)
        {
            isDefaultValues = false;
        }

        _typeClearButton.gameObject.SetActive(!isDefaultValues);
    }

    void UpdateTypeSelectAllButtonVisibility()
    {
        foreach(var toggle in _typeToggles)
        {
            if(!toggle.isOn)
            {
                _selectAllTypesButton.interactable = true;
                return;
            }
        }

        _selectAllTypesButton.interactable = false;
    }

    void UpdateTypeUnselectAllButtonVisibility()
    {
        foreach (var toggle in _typeToggles)
        {
            if (toggle.isOn)
            {
                _unselectAllTypesButton.interactable = true;
                return;
            }
        }

        _unselectAllTypesButton.interactable = false;
    }
}
