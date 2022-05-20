using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RarityLoot
{
    [SerializeField] private Loot loot;
    [SerializeField] private float rarity;

    public Loot Loot => loot;
    public float Rarity => rarity;
}
