using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    [SerializeField] private Consumable medicineConsumable;

    public Consumable MedicineConsumable => medicineConsumable; 

    abstract public IEnumerator EffctCoroutine(Hero hero,StatusEffectСontainer statusEffectСontainer);
    abstract public void RemoveStatus(Hero hero); 

}
