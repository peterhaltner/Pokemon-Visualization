using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public List<GameObject> PokemonNodes { get { return _pokemonNodes; } }

    List<GameObject> _pokemonNodes = new List<GameObject>();

    public void AddPokemonNode(GameObject node)
    {
        _pokemonNodes.Add(node);
    }
}
