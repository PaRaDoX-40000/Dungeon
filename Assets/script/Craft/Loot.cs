using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="loot new", menuName ="Loot/loot", order = 51)]
public class Loot : ScriptableObject
{
    private Sprite icon;
    private string lootName;
    //int stack;  
    private StatsApp statsApp;

    public Sprite Icon => icon;
    public string LootName  => lootName; 
    public StatsApp StatsApp => statsApp;
}
