using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Improvement : ScriptableObject
{
    public enum ImprovedStructure
    {
        Hub = 0,
        Forge = 1,
        Laboratory = 2,
        Barracks = 3,
        Trade = 4
    }
   

    protected int level = 1;
    [SerializeField] private Ingredient[] resources;
    [SerializeField] private int gold;
    [SerializeField] private string title;
    [SerializeField] private string description;
    private bool canCreate = false;

    [SerializeField] private ImprovedStructure nameImprovedStructure;

    [SerializeField] public DataBase dataBase;

    public Ingredient[] Resources => resources;
    public int Gold => gold; 
    public string Title => title;
    public string Description => description;
    public bool CanCreate => canCreate;
    public ImprovedStructure NameImprovedStructure => nameImprovedStructure;

    public bool CanBeImproved()
    {
        bool canCreate = false;
        foreach (Ingredient i in Resources)
        {
            if (this.dataBase.loots.ContainsKey(i.Loot))
            {
                if (this.dataBase.loots[i.Loot] < i.Number)
                {
                    canCreate = false;
                    return canCreate;
                }
            }
            else
            {
                canCreate = false;
                return canCreate;
            }
            canCreate = true;
        }
        if (this.dataBase.gold < Gold)
        {
            canCreate = false;
        }
        return canCreate;
    }

    abstract public void levelUp();
}
  

