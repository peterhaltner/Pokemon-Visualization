using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvReader : MonoBehaviour
{
    [SerializeField] GameObject _pokemonNodePrefab;
    [SerializeField] Transform _pokemonNodesRoot;
    [SerializeField] DataHandler _dataHandler;

    const string _csvPath = "Assets/Data/Pokemon.csv"; //path to Pokemon database

    //An enum to match the index with column number in CSV
    enum PokemonData
    {
        Number,
        Name,
        Type1,
        Type2,
        Total,
        HP,
        Attack,
        Defense,
        SpAtk,
        SpDef,
        Speed,
        Generation,
        Legendary
    }

    void Awake()
    {
        string rawData = System.IO.File.ReadAllText(_csvPath); //Read the database file

        string[] rawDataLines = rawData.Split("\n"[0]);

        //For each pokemon, note we skip the first line which are the titles. Last line is null thus also ignored.
        for(int i=1; i<rawDataLines.Length - 1; i++)
        {
            string[] pokemonData = (rawDataLines[i].Trim()).Split(","[0]); //Gather Data for Pokemon

            var pokemonNode = GameObject.Instantiate(_pokemonNodePrefab, _pokemonNodesRoot); //Instaniate a new node for Pokemon

            _dataHandler.AddPokemonNode(pokemonNode);

            //Update Pokemon node information with data values
            pokemonNode.GetComponent<NodeInformationController>().SetNodeInformation(
                pokemonData[(int)PokemonData.Name],
                pokemonData[(int)PokemonData.Type1],
                pokemonData[(int)PokemonData.Type2],
                pokemonData[(int)PokemonData.Total],
                pokemonData[(int)PokemonData.HP],
                pokemonData[(int)PokemonData.Attack],
                pokemonData[(int)PokemonData.Defense],
                pokemonData[(int)PokemonData.SpAtk],
                pokemonData[(int)PokemonData.SpDef],
                pokemonData[(int)PokemonData.Speed],
                pokemonData[(int)PokemonData.Generation],
                pokemonData[(int)PokemonData.Legendary]
            );
        }

        //Set default axis values
        _dataHandler.SetAxisTypes(DataHandler.AxisTypes.HP, DataHandler.AxisTypes.Attack, DataHandler.AxisTypes.Speed);
    }
}
