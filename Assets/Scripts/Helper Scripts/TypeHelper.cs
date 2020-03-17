using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeHelper : MonoBehaviour
{
    public enum Type
    {
        None,
        Bug,
        Dark,
        Dragon,
        Electric,
        Fairy,
        Fighting,
        Fire,
        Flying,
        Ghost,
        Grass,
        Ground,
        Ice,
        Normal,
        Poison,
        Psychic,
        Rock,
        Steel,
        Water
    }

    //Update if more types added
    public static int NumberOfTypes { get { return 18; } }

    public static Type ParseType(string type)
    {
        switch (type)
        {
            case "":
                return Type.None;
            case "Bug":
                return Type.Bug;
            case "Dark":
                return Type.Dark;
            case "Dragon":
                return Type.Dragon;
            case "Electric":
                return Type.Electric;
            case "Fairy":
                return Type.Fairy;
            case "Fighting":
                return Type.Fighting;
            case "Fire":
                return Type.Fire;
            case "Flying":
                return Type.Flying;
            case "Ghost":
                return Type.Ghost;
            case "Grass":
                return Type.Grass;
            case "Ground":
                return Type.Ground;
            case "Ice":
                return Type.Ice;
            case "Normal":
                return Type.Normal;
            case "Poison":
                return Type.Poison;
            case "Psychic":
                return Type.Psychic;
            case "Rock":
                return Type.Rock;
            case "Steel":
                return Type.Steel;
            case "Water":
                return Type.Water;
            default:
                Debug.LogErrorFormat("Cannot find type match for given string '{0}'", type);
                return Type.None;
        }
    }
}
