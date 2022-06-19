using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Consumable/Consumable", order = 51)]
public class Consumable : ScriptableObject
{
    
    [SerializeField] private Sprite icon;
    [SerializeField] private string description;
    

    public Sprite Icon => icon;
    public string Description => description;
   
}
