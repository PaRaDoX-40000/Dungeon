using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffectСhance
{
    [SerializeField] private StatusEffect statusEffect;
    [Range(0, 100)]
    [SerializeField] private int chance;

    public StatusEffect StatusEffect => statusEffect;

    public int Сhance => chance;
}
