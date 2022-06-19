using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusEffectPoison", menuName = "StatusEffect/Poison", order = 51)]
public class StatusEffectPoison : StatusEffect
{
    [SerializeField] private int damagePerTick;
    [SerializeField] private int numberTicks;
      
    public override IEnumerator EffctCoroutine(Hero hero,StatusEffectСontainer statusEffectСontainer)
    {       
        int i = 0;
        while (numberTicks > i)
        {
            yield return new WaitForSeconds(3);           
            hero.TakeDamageWithoutArmor(damagePerTick);
            i++;
        }
        RemoveStatus(hero);
        statusEffectСontainer.RemoveStatus(hero);
    }
    public override void RemoveStatus(Hero hero)
    {                 
    }  
}
