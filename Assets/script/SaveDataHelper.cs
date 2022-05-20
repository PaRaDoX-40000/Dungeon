using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveDataHelper
{
    public List<Loot> loots = new List<Loot>();
    public List<int> lootsNumber = new List<int>();
    public List<Consumable> consumables = new List<Consumable>();
    public List<int> consumablesNumber = new List<int>();

    public void Save(Dictionary<Loot,int> dictLoots, Dictionary<Consumable, int> dictConsumables)
    {
        loots.Clear();
        lootsNumber.Clear();
        Dictionary<Loot, int>.KeyCollection lootsKey = dictLoots.Keys;
        foreach (Loot i in lootsKey)
        {
           
            loots.Add(i);
            lootsNumber.Add(dictLoots[i]);

        }
        consumables.Clear();
        consumablesNumber.Clear();
        Dictionary<Consumable, int>.KeyCollection consumableKey = dictConsumables.Keys;
        foreach (Consumable i in consumableKey)
        {
            consumables.Add(i);
            consumablesNumber.Add(dictConsumables[i]);
            Debug.Log(i + " " + dictConsumables[i]);

        }
        

    }
    public void Loading(ref Dictionary<Loot, int> dictLoots, ref Dictionary<Consumable, int> dictConsumables)
    {
        dictLoots = new Dictionary<Loot, int>();
        dictConsumables = new Dictionary<Consumable, int>();
        
        for (int i = 0; i < loots.Count; i++)
        {
            dictLoots.Add(loots[i], lootsNumber[i]);          
        }

        

        
        for (int i = 0; i < consumables.Count; i++)
        {
           

            dictConsumables.Add(consumables[i], consumablesNumber[i]);
            

        }
        
    }
}
