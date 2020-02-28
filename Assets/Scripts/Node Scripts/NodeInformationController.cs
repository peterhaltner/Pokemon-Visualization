using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInformationController : MonoBehaviour
{
    [SerializeField] NodeAppearance _nodeAppearance;

    //Pokemon Attributes
    public string Name { get; private set; }
    public TypeHelper.Type Type1 { get; private set; }
    public TypeHelper.Type Type2 { get; private set; }
    public int Total { get; private set; } //May remove if not needed
    public int HP { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int SpecialAttack { get; private set; }
    public int SpecialDefense { get; private set; }
    public int Speed { get; private set; }
    public int Generation { get; private set; }
    public bool IsLegendary { get; private set; }


    //To be called when the Pokemon Node is created
    public void SetNodeInformation(
        string name,
        string type1,
        string type2,
        string total,
        string hp,
        string attack,
        string defense,
        string spAtk,
        string spDef,
        string speed,
        string generation,
        string legendary)
    {
        //Set all Pokemon information to this particular node
        this.name = name;
        Name = name;

        Type1 = TypeHelper.ParseType(type1);
        Type2 = TypeHelper.ParseType(type2);

        Total = int.Parse(total);
        HP = int.Parse(hp);
        Attack = int.Parse(attack);
        Defense = int.Parse(defense);
        SpecialAttack = int.Parse(spAtk);
        SpecialDefense = int.Parse(spDef);
        Speed = int.Parse(speed);
        Generation = int.Parse(generation);

        IsLegendary = bool.Parse(legendary);

        //Call other methods dependent on these values
        _nodeAppearance.SetupAppearance();
    }
}
