using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.Reflection;
using System;

public class DataHandler : MonoBehaviour
{
    public enum AxisTypes
    { 
        None,
        HP,
        Attack,
        Defense,
        SpecialAttack,
        SpecialDefense,
        Speed,
    }

    public enum Axis
    {
        X,
        Y,
        Z,
    }

    public List<GameObject> PokemonNodes { get { return _pokemonNodes; } }

    [SerializeField] AxisController _axisController;

    List<GameObject> _pokemonNodes = new List<GameObject>();

    AxisTypes _xAxisType;
    AxisTypes _yAxisType;
    AxisTypes _zAxisType;

    void Start()
    {
        //Set default axis values - mirrored from default UI settings
        _xAxisType = AxisTypes.HP;
        _yAxisType = AxisTypes.Attack;
        _zAxisType = AxisTypes.Defense;

        SetAxisTypes(_xAxisType, _yAxisType, _zAxisType);
    }

    public void AddPokemonNode(GameObject node)
    {
        _pokemonNodes.Add(node);
    }

    public void UpdateAxisType(Axis axis, string friendlyAxisTypeText)
    {
        switch(axis)
        {
            case Axis.X:
                _xAxisType = GetAxisTypeFromFriendlyText(friendlyAxisTypeText);
                break;
            case Axis.Y:
                _yAxisType = GetAxisTypeFromFriendlyText(friendlyAxisTypeText);
                break;
            case Axis.Z:
                _zAxisType = GetAxisTypeFromFriendlyText(friendlyAxisTypeText);
                break;
        }

        SetAxisTypes(_xAxisType, _yAxisType, _zAxisType);
    }

    //TODO: Redesign such that it does not take parameters in
    void SetAxisTypes(AxisTypes xType, AxisTypes yType, AxisTypes zType)
    {
        //Ensure only one is of type None at most
        if((xType == AxisTypes.None && (yType == xType || zType == xType)) ||
            (yType == AxisTypes.None && zType == yType))
        {
            Debug.LogError("Can only have one axis type be none at most");
            return;
        }

        //Change text values of axis
        _axisController.SetAxisText(GetEnumFriendlyText(xType), AxisController.Axises.X);
        _axisController.SetAxisText(GetEnumFriendlyText(yType), AxisController.Axises.Y);
        _axisController.SetAxisText(GetEnumFriendlyText(zType), AxisController.Axises.Z);

        //Update all Pokemon nodes to have new value (TODO: Make smooth transition)
        foreach(var node in _pokemonNodes)
        {
            var nodeInfo = node.GetComponent<NodeInformationController>();

            //Move to position 
            node.transform.position = new Vector3(
                GetValueFromAxisType(nodeInfo, xType),
                GetValueFromAxisType(nodeInfo, yType),
                GetValueFromAxisType(nodeInfo, zType)
            );
        }
    }

    string GetEnumFriendlyText(AxisTypes axisType)
    {
        switch(axisType)
        {
            case AxisTypes.Attack:
                return "Attack";
            case AxisTypes.Defense:
                return "Defense";
            case AxisTypes.HP:
                return "HP";
            case AxisTypes.None:
                return "";
            case AxisTypes.SpecialAttack:
                return "Special Attack";
            case AxisTypes.SpecialDefense:
                return "Special Defense";
            case AxisTypes.Speed:
                return "Speed";
            default:
                Debug.LogError("Enum friendly text not found");
                return "ERROR";
        }
    }

    AxisTypes GetAxisTypeFromFriendlyText(string enumFriendlyText)
    {
        switch (enumFriendlyText)
        {
            case "Attack":
                return AxisTypes.Attack;
            case "Defense":
                return AxisTypes.Defense;
            case "HP":
                return AxisTypes.HP;
            case "":
                return AxisTypes.None;
            case "Special Attack":
                return AxisTypes.SpecialAttack;
            case "Special Defense":
                return AxisTypes.SpecialDefense;
            case "Speed":
                return AxisTypes.Speed;
            default:
                Debug.LogErrorFormat("Enum friendly text did not match any found '{0}'", enumFriendlyText);
                return AxisTypes.None;
        }
    }

    int GetValueFromAxisType(NodeInformationController nodeInfo, AxisTypes attribute)
    {
        switch(attribute)
        {
            case AxisTypes.Attack:
                return nodeInfo.Attack;
            case AxisTypes.Defense:
                return nodeInfo.Defense;
            case AxisTypes.HP:
                return nodeInfo.HP;
            case AxisTypes.None:
                return 0;
            case AxisTypes.SpecialAttack:
                return nodeInfo.SpecialAttack;
            case AxisTypes.SpecialDefense:
                return nodeInfo.SpecialDefense;
            case AxisTypes.Speed:
                return nodeInfo.Speed;
            default:
                Debug.LogError("Attribute not found");
                return 0;
        }
    }
}
