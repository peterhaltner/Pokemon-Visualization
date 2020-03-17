using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FilterHandler : MonoBehaviour
{
    [SerializeField] DataHandler _dataHandler;

    public enum FilterType
    {
        CanMatchAny,
        MustMatchAll,
    }

    public int NumberPokemonFilterMatched { get; private set; }

    List<GenerationHelper.Generations> _activeGenerationFilters = new List<GenerationHelper.Generations>();
    List<TypeHelper.Type> _activeTypeFilters = new List<TypeHelper.Type>();
    FilterType _typeFilterType;

    string _nameFilter = "";

    bool? _mustBeLegendary; //null means any

    void Start()
    {
        AddAllTypeFilters();
        AddAllGenerationFilters();
    }

    public void SetNameFilter(string nameFilter)
    {
        _nameFilter = nameFilter;
        ApplyFilters();
    }

    public void ClearTypeFilters()
    {
        _activeTypeFilters.Clear();
        ApplyFilters();
    }

    public void AddTypeFilter(TypeHelper.Type type)
    {
        _activeTypeFilters.Add(type);
        ApplyFilters();
    }

    public void RemoveTypeFilter(TypeHelper.Type type)
    {
        _activeTypeFilters.Remove(type);
        ApplyFilters();
    }

    public void SetTypeFilters(FilterType filterType)
    {
        _typeFilterType = filterType;
        ApplyFilters();
    }

    public void AddGenerationFilter(GenerationHelper.Generations generation)
    {
        _activeGenerationFilters.Add(generation);
        ApplyFilters();
    }

    public void RemoveGenerationFilter(GenerationHelper.Generations generation)
    {
        _activeGenerationFilters.Remove(generation);
        ApplyFilters();
    }

    public void SetMustBeLegendaryFilter(bool? mustBeLegendary)
    {
        _mustBeLegendary = mustBeLegendary;
        ApplyFilters();
    }

    void ApplyFilters()
    {
        int numFilterMatched = 0;

        foreach(var node in _dataHandler.PokemonNodes)
        {
            bool isFilteredOut = false;
            NodeInformationController nodeInfo = node.GetComponent<NodeInformationController>();

            //Name Filter
            if(_nameFilter != "")
            {
                isFilteredOut = node.name.IndexOf(_nameFilter, StringComparison.OrdinalIgnoreCase) < 0; //ignores case when checking if filter is contained by name
            }

            //Type filter
            if(!isFilteredOut)
            {
                if(_typeFilterType == FilterType.CanMatchAny && _activeTypeFilters.Count != TypeHelper.NumberOfTypes)
                {
                    bool hasMatchedAny = false;

                    foreach(var type in _activeTypeFilters)
                    {
                        if(nodeInfo.Type1 == type || nodeInfo.Type2 == type)
                        {
                            hasMatchedAny = true;
                            break;
                        }
                    }

                    isFilteredOut = !hasMatchedAny;
                }
                else if(_typeFilterType == FilterType.MustMatchAll)
                {
                    if(_activeTypeFilters.Count == 0)
                    {
                        isFilteredOut = true;
                    }

                    foreach (var type in _activeTypeFilters)
                    {
                        if (nodeInfo.Type1 != type && nodeInfo.Type2 != type)
                        {
                            isFilteredOut = true;
                            break;
                        }
                    }
                }
            }

            //Generation filter - if none match then filter it out
            if(!isFilteredOut && _activeGenerationFilters.Count != GenerationHelper.NumberOfGenerations)
            {
                var nodeGeneration = GenerationHelper.ParseGeneration(nodeInfo.Generation);
                isFilteredOut = !_activeGenerationFilters.Contains(nodeGeneration);
            }

            //Legendary filter
            if(!isFilteredOut && _mustBeLegendary.HasValue)
            {
                if (_mustBeLegendary.Value == false && nodeInfo.IsLegendary == false)
                {
                    isFilteredOut = false;
                }
                else if (_mustBeLegendary.Value == true && nodeInfo.IsLegendary == true)
                {
                    isFilteredOut = false;
                }
                else
                {
                    isFilteredOut = true;
                }
            }

            //Apply filtering applications
            node.GetComponent<NodeStateController>().SetActive(!isFilteredOut);

            if(!isFilteredOut)
            {
                numFilterMatched++;
            }
        }

        NumberPokemonFilterMatched = numFilterMatched;
    }

    void AddAllTypeFilters()
    {
        _activeTypeFilters.Clear();

        _activeTypeFilters.Add(TypeHelper.Type.Bug);
        _activeTypeFilters.Add(TypeHelper.Type.Dark);
        _activeTypeFilters.Add(TypeHelper.Type.Dragon);
        _activeTypeFilters.Add(TypeHelper.Type.Electric);
        _activeTypeFilters.Add(TypeHelper.Type.Fairy);
        _activeTypeFilters.Add(TypeHelper.Type.Fighting);
        _activeTypeFilters.Add(TypeHelper.Type.Fire);
        _activeTypeFilters.Add(TypeHelper.Type.Flying);
        _activeTypeFilters.Add(TypeHelper.Type.Ghost);
        _activeTypeFilters.Add(TypeHelper.Type.Grass);
        _activeTypeFilters.Add(TypeHelper.Type.Ground);
        _activeTypeFilters.Add(TypeHelper.Type.Ice);
        _activeTypeFilters.Add(TypeHelper.Type.Normal);
        _activeTypeFilters.Add(TypeHelper.Type.Poison);
        _activeTypeFilters.Add(TypeHelper.Type.Psychic);
        _activeTypeFilters.Add(TypeHelper.Type.Rock);
        _activeTypeFilters.Add(TypeHelper.Type.Steel);
        _activeTypeFilters.Add(TypeHelper.Type.Water);

        ApplyFilters();
    }

    void AddAllGenerationFilters()
    {
        _activeGenerationFilters.Clear();

        _activeGenerationFilters.Add(GenerationHelper.Generations.Gen1);
        _activeGenerationFilters.Add(GenerationHelper.Generations.Gen2);
        _activeGenerationFilters.Add(GenerationHelper.Generations.Gen3);
        _activeGenerationFilters.Add(GenerationHelper.Generations.Gen4);
        _activeGenerationFilters.Add(GenerationHelper.Generations.Gen5);
        _activeGenerationFilters.Add(GenerationHelper.Generations.Gen6);

        ApplyFilters();
    }
}
