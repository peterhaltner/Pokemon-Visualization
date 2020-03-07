using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFilterHandler : MonoBehaviour
{
    [SerializeField] Text _pokemonFilterAmountStatus;

    //TODO: Continue here with Filtering

    [SerializeField] DataHandler _dataHandler;
    [SerializeField] FilterHandler _filterHandler;

    void UpdateFilterAmountStatus()
    {
        _pokemonFilterAmountStatus.text = "Displaying "
            + _filterHandler.NumberPokemonFilterMatched 
            + "/"
            + _dataHandler.NumberOfPokemon
            + " Pokémon";
    }
}
