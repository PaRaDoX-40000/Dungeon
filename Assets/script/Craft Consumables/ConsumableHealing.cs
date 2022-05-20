using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Consumable", menuName = "Consumable/ConsumableHealing", order = 51)]
public class ConsumableHealing : Consumable
{
    [SerializeField] private int amountHealing;

    public int AmountHealing => amountHealing;
}
