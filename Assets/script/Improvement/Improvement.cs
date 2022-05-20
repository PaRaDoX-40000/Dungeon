using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Improvement : ScriptableObject
{
    //public CommonHeir commonHeir;ImprovementMaxLootCraft

    public int level = 1;
    [SerializeField] private Ingredient[] resources;
    [SerializeField] private int gold;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private bool canCreate = false;
    [SerializeField] public CommonHeir commonHeir;

    public Ingredient[] Resources => resources;
    public int Gold => gold; 
    public string Title => title;
    public string Description => description;
    public bool CanCreate => canCreate; 
    

    //public int Level => level;

    public bool CanBeImproved(CommonHeir commonHeir)
    {
        bool canCreate = false;
        foreach (Ingredient i in Resources)
        {
            if (commonHeir.dataBase.loots.ContainsKey(i.Loot))
            {

                if (commonHeir.dataBase.loots[i.Loot] < i.Number)
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
        if (commonHeir.dataBase.gold < Gold)
        {
            canCreate = false;
        }
        return canCreate;
    }

    abstract public void levelUp();
}
  

