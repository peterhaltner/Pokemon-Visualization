using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    [SerializeField] UIHoverPanelHandler _uiHoverHandler;
    [SerializeField] UISelectedPanelHandler _uiSelectHandler;

    GameObject _selectedPokemon;
    GameObject _hoveredPokemon;

    void Start()
    {
        _uiHoverHandler.SetHoverUiActive(false);
        _uiSelectHandler.SetSelectedUiActive(false);
    }

    void Update()
    {
        //Check if mouse is hovering over a Pokemon node
        RaycastHit hit;
        Ray ray = CameraStateController.ActiveCamera.ScreenPointToRay(Input.mousePosition);

        GameObject newHoveredPokemon = null;
        GameObject newSelectedPokemon = null;

        //Exit if pointer is over UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

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
                    _uiHoverHandler.SetHoverUiActive(false);
                }
            }

            //Case 2: it was hovering over nothing, now hovering over Pokemon
            else if (_hoveredPokemon == null)
            {
                NodeStateController newStateController = newHoveredPokemon.GetComponent<NodeStateController>();

                if(newStateController.ActiveState != NodeStateController.State.Selected)
                {
                    newStateController.SetState(NodeStateController.State.Hovered);
                    _uiHoverHandler.UpdateHoverTextUI(newHoveredPokemon);
                    _uiHoverHandler.SetHoverUiActive(true);
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
                    _uiHoverHandler.UpdateHoverTextUI(newHoveredPokemon);
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
                _uiSelectHandler.SetSelectedUiActive(false);
            }

            if(newSelectedPokemon != null)
            {
                NodeStateController newStateController = newSelectedPokemon.GetComponent<NodeStateController>();
                newStateController.SetState(NodeStateController.State.Selected);
                _uiSelectHandler.UpdateSelectedTextUI(newSelectedPokemon);
                _uiSelectHandler.SetSelectedUiActive(true);
            }

            _selectedPokemon = newSelectedPokemon;
        }
    }
}
