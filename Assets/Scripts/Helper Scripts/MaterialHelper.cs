using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHelper : MonoBehaviour
{
    public enum MaterialType
    {
        Type,
        Generation,
    }

    [SerializeField] Material _bugMaterial;
    [SerializeField] Material _darkMaterial;
    [SerializeField] Material _dragonMaterial;
    [SerializeField] Material _electricMaterial;
    [SerializeField] Material _fairyMaterial;
    [SerializeField] Material _fightingMaterial;
    [SerializeField] Material _fireMaterial;
    [SerializeField] Material _flyingMaterial;
    [SerializeField] Material _ghostMaterial;
    [SerializeField] Material _grassMaterial;
    [SerializeField] Material _groundMaterial;
    [SerializeField] Material _iceMaterial;
    [SerializeField] Material _normalMaterial;
    [SerializeField] Material _poisonMaterial;
    [SerializeField] Material _psychicMaterial;
    [SerializeField] Material _rockMaterial;
    [SerializeField] Material _steelMaterial;
    [SerializeField] Material _waterMaterial;

    [SerializeField] Material _bugTransMaterial;
    [SerializeField] Material _darkTransMaterial;
    [SerializeField] Material _dragonTransMaterial;
    [SerializeField] Material _electricTransMaterial;
    [SerializeField] Material _fairyTransMaterial;
    [SerializeField] Material _fightingTransMaterial;
    [SerializeField] Material _fireTransMaterial;
    [SerializeField] Material _flyingTransMaterial;
    [SerializeField] Material _ghostTransMaterial;
    [SerializeField] Material _grassTransMaterial;
    [SerializeField] Material _groundTransMaterial;
    [SerializeField] Material _iceTransMaterial;
    [SerializeField] Material _normalTransMaterial;
    [SerializeField] Material _poisonTransMaterial;
    [SerializeField] Material _psychicTransMaterial;
    [SerializeField] Material _rockTransMaterial;
    [SerializeField] Material _steelTransMaterial;
    [SerializeField] Material _waterTransMaterial;

    [SerializeField] Material _gen1Material;
    [SerializeField] Material _gen2Material;
    [SerializeField] Material _gen3Material;
    [SerializeField] Material _gen4Material;
    [SerializeField] Material _gen5Material;
    [SerializeField] Material _gen6Material;

    [SerializeField] Material _gen1TransMaterial;
    [SerializeField] Material _gen2TransMaterial;
    [SerializeField] Material _gen3TransMaterial;
    [SerializeField] Material _gen4TransMaterial;
    [SerializeField] Material _gen5TransMaterial;
    [SerializeField] Material _gen6TransMaterial;

    public Material GetMaterial(TypeHelper.Type type, bool isTransparent)
    {
        if (!isTransparent)
        {
            switch (type)
            {
                case TypeHelper.Type.Bug:
                    return _bugMaterial;
                case TypeHelper.Type.Dark:
                    return _darkMaterial;
                case TypeHelper.Type.Dragon:
                    return _dragonMaterial;
                case TypeHelper.Type.Electric:
                    return _electricMaterial;
                case TypeHelper.Type.Fairy:
                    return _fairyMaterial;
                case TypeHelper.Type.Fighting:
                    return _fightingMaterial;
                case TypeHelper.Type.Fire:
                    return _fireMaterial;
                case TypeHelper.Type.Flying:
                    return _flyingMaterial;
                case TypeHelper.Type.Ghost:
                    return _ghostMaterial;
                case TypeHelper.Type.Grass:
                    return _grassMaterial;
                case TypeHelper.Type.Ground:
                    return _groundMaterial;
                case TypeHelper.Type.Ice:
                    return _iceMaterial;
                case TypeHelper.Type.Normal:
                    return _normalMaterial;
                case TypeHelper.Type.Poison:
                    return _poisonMaterial;
                case TypeHelper.Type.Psychic:
                    return _psychicMaterial;
                case TypeHelper.Type.Rock:
                    return _rockMaterial;
                case TypeHelper.Type.Steel:
                    return _steelMaterial;
                case TypeHelper.Type.Water:
                    return _waterMaterial;
                default:
                    Debug.LogError("No type specified, no material exists for none");
                    return null;
            }
        }
        else
        {
            switch (type)
            {
                case TypeHelper.Type.Bug:
                    return _bugTransMaterial;
                case TypeHelper.Type.Dark:
                    return _darkTransMaterial; ;
                case TypeHelper.Type.Dragon:
                    return _dragonTransMaterial; ;
                case TypeHelper.Type.Electric:
                    return _electricTransMaterial; ;
                case TypeHelper.Type.Fairy:
                    return _fairyTransMaterial; ;
                case TypeHelper.Type.Fighting:
                    return _fightingTransMaterial; ;
                case TypeHelper.Type.Fire:
                    return _fireTransMaterial; ;
                case TypeHelper.Type.Flying:
                    return _flyingTransMaterial; ;
                case TypeHelper.Type.Ghost:
                    return _ghostTransMaterial; ;
                case TypeHelper.Type.Grass:
                    return _grassTransMaterial; ;
                case TypeHelper.Type.Ground:
                    return _groundTransMaterial; ;
                case TypeHelper.Type.Ice:
                    return _iceTransMaterial; ;
                case TypeHelper.Type.Normal:
                    return _normalTransMaterial; ;
                case TypeHelper.Type.Poison:
                    return _poisonTransMaterial; ;
                case TypeHelper.Type.Psychic:
                    return _psychicTransMaterial; ;
                case TypeHelper.Type.Rock:
                    return _rockTransMaterial; ;
                case TypeHelper.Type.Steel:
                    return _steelTransMaterial; ;
                case TypeHelper.Type.Water:
                    return _waterTransMaterial; ;
                default:
                    Debug.LogError("No type specified, no transparent material exists for none");
                    return null;
            }
        }
    }

    public Material GetMaterial(GenerationHelper.Generations generation, bool isTransparent)
    {
        if (!isTransparent)
        {
            switch (generation)
            {
                case GenerationHelper.Generations.Gen1:
                    return _gen1Material;
                case GenerationHelper.Generations.Gen2:
                    return _gen2Material;
                case GenerationHelper.Generations.Gen3:
                    return _gen3Material;
                case GenerationHelper.Generations.Gen4:
                    return _gen4Material;
                case GenerationHelper.Generations.Gen5:
                    return _gen5Material;
                case GenerationHelper.Generations.Gen6:
                    return _gen6Material;
                default:
                    Debug.LogError("No generation specified, no material exists for none");
                    return null;
            }
        }
        else
        {
            switch (generation)
            {
                case GenerationHelper.Generations.Gen1:
                    return _gen1TransMaterial;
                case GenerationHelper.Generations.Gen2:
                    return _gen2TransMaterial;
                case GenerationHelper.Generations.Gen3:
                    return _gen3TransMaterial;
                case GenerationHelper.Generations.Gen4:
                    return _gen4TransMaterial;
                case GenerationHelper.Generations.Gen5:
                    return _gen5TransMaterial;
                case GenerationHelper.Generations.Gen6:
                    return _gen6TransMaterial;
                default:
                    Debug.LogError("No generation specified, no transparent material exists for none");
                    return null;
            }
        }
    }
}
