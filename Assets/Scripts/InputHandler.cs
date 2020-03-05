﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] Camera _camera;

    GameObject _selectedPokemon;
    GameObject _hoveredPokemon;

    void Update()
    {
        //Check if mouse is hovering over a Pokemon node
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        GameObject newHoveredPokemon = null;
        GameObject newSelectedPokemon = null;

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if(objectHit.tag == "Pokemon")
            {
                newHoveredPokemon = objectHit.gameObject;

                //If user released left mouse button, checked for selected too
                if(Input.GetMouseButtonUp(0))
                {
                    newSelectedPokemon = objectHit.gameObject;
                }
            }
        }
        
        //Update which is hovered now
        if(newHoveredPokemon != _hoveredPokemon)
        {
            //TODO: Could probably compact logic of this

            //Case 1: Was hovering over Pokemon, not hovering anymore
            if (newHoveredPokemon == null)
            {
                NodeStateController previousStateController = _hoveredPokemon.GetComponent<NodeStateController>();

                if(previousStateController.ActiveState != NodeStateController.State.Selected)
                {
                    previousStateController.SetState(NodeStateController.State.Default);
                }
            }

            //Case 2: it was hovering over nothing, now hovering over Pokemon
            else if (_hoveredPokemon == null)
            {
                NodeStateController newStateController = newHoveredPokemon.GetComponent<NodeStateController>();

                if(newStateController.ActiveState != NodeStateController.State.Selected)
                {
                    newStateController.SetState(NodeStateController.State.Hovered);
                }
            }

            //Case 3: It was hovering over one pokemon, and directly started hovering over another Pokemon
            else
            {
                NodeStateController previousStateController = _hoveredPokemon.GetComponent<NodeStateController>();
                NodeStateController newStateController = newHoveredPokemon.GetComponent<NodeStateController>();

                if(previousStateController.ActiveState != NodeStateController.State.Selected)
                {
                    previousStateController.SetState(NodeStateController.State.Default);
                }

                if (newStateController.ActiveState != NodeStateController.State.Selected)
                {
                    newStateController.SetState(NodeStateController.State.Hovered);
                }
            }
            _hoveredPokemon = newHoveredPokemon;
        }

        //Update which is selected
        if(newSelectedPokemon != _selectedPokemon && Input.GetMouseButtonUp(0))
        {
            if(_selectedPokemon != null)
            {
                NodeStateController previousStateController = _selectedPokemon.GetComponent<NodeStateController>();
                previousStateController.SetState(NodeStateController.State.Default);
            }

            if(newSelectedPokemon != null)
            {
                NodeStateController newStateController = newSelectedPokemon.GetComponent<NodeStateController>();
                newStateController.SetState(NodeStateController.State.Selected);
            }

            _selectedPokemon = newSelectedPokemon;
        }
    }
}