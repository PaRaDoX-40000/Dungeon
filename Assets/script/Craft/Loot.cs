using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="loot new", menuName ="Loot/loot", order = 51)]
public class Loot : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private string lootName;  
    [SerializeField] private StatsApp statsApp;

    public Sprite Icon => icon;
    public string LootName  => lootName; 
    public StatsApp StatsApp => statsApp;
}
