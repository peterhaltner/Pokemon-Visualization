using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationHelper : MonoBehaviour
{
    public enum Generations
    {
        Default,
        Gen1,
        Gen2,
        Gen3,
        Gen4,
        Gen5,
        Gen6,
    }

    public static int NumberOfGenerations { get { return 6; } }

    public static Generations ParseGeneration(int generation)
    {
        switch (generation)
        {
            case 1:
                return Generations.Gen1;
            case 2:
                return Generations.Gen2;
            case 3:
                return Generations.Gen3;
            case 4:
                return Generations.Gen4;
            case 5:
                return Generations.Gen5;
            case 6:
                return Generations.Gen6;
            default:
                Debug.LogErrorFormat("Generation number does not exist '{0}'", generation);
                return Generations.Default;
        }
    }
}
