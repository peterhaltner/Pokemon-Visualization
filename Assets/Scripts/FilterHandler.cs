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

    public enum GenerationFilters
    {
        Default,
        Gen1,
        Gen2,
        Gen3,
        Gen4,
        Gen5,
        Gen6,
    }

    List<GenerationFilters> _activeGenerationFilters = new List<GenerationFilters>();

    List<TypeHelper.Type> _activeTypeFilters = new List<TypeHelper.Type>();
    FilterType _typeFilterType;

    string _nameFilter = "";

    bool? _mustBeLegendary; //null means any

    void Start()
    {
        ApplyFilters();
    }

    public void SetNameFilter(string nameFilter)
    {
        _nameFilter = nameFilter;
        ApplyFilters();
    }

    public void SetTypeFilters(List<TypeHelper.Type> typeFilters, FilterType filterType)
    {
        _activeTypeFilters = typeFilters;
        _typeFilterType = filterType;
        ApplyFilters();
    }

    public void SetGenerationFilters(List<GenerationFilters> generationFilters)
    {
        _activeGenerationFilters = generationFilters;
        ApplyFilters();
    }

    public void SetMustBeLegendaryFilter(bool? mustBeLegendary)
    {
        _mustBeLegendary = mustBeLegendary;
        ApplyFilters();
    }

    void ApplyFilters()
    {
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
            if(!isFilteredOut && _activeTypeFilters.Count != 0)
            {
                if(_typeFilterType == FilterType.CanMatchAny)
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
            if(!isFilteredOut && _activeGenerationFilters.Count != 0)
            {
                GenerationFilters nodeGeneration = GenerationFilters.Default;

                switch(nodeInfo.Generation)
                {
                    case 1:
                        nodeGeneration = GenerationFilters.Gen1;
                        break;
                    case 2:
                        nodeGeneration = GenerationFilters.Gen2;
                        break;
                    case 3:
                        nodeGeneration = GenerationFilters.Gen3;
                        break;
                    case 4:
                        nodeGeneration = GenerationFilters.Gen4;
                        break;
                    case 5:
                        nodeGeneration = GenerationFilters.Gen5;
                        break;
                    case 6:
                        nodeGeneration = GenerationFilters.Gen6;
                        break;
                }

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
        }
    }
}
