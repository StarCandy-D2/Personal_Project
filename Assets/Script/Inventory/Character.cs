using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public float EXP {  get; private set; }
    public int Attack {  get; private set; }
    public int DEF { get; private set; }
    public int HP { get; private set; }
    public float Crit { get; private set; }

    public List<Item> Inventory { get; private set; }

    public Character(string name, int level,float exp,int attack, int def, int hp, float crit)
    {
        Name = name;
        Level = level;
        EXP = exp;
        Attack = attack;
        DEF = def;
        HP = hp;
        Crit = crit;
        Inventory = new List<Item>();
    }
}
