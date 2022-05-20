using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighRegeneration", menuName = "Peculiarities/Effect/HighRegeneration", order = 51)]
public class EffectHighRegeneration : Effect
{
    [SerializeField] private int recoveryPercentage;

    public override void effect(Enemy enemy, Hero hero, Fight fight, Adventure adventure)
    {
        
    }

    public override void effect(Loot loot, Adventure adventure)
    {
        
    }

    
    public override void effect(int amountHeal, Hero hero, Fight fight)
    {
        hero.ChangeHealth((int)(amountHeal * ((float)recoveryPercentage / 100f)));
    }
    public override void effect(Damage damage, Enemy enemy, Hero hero, Fight fight)
    {

    }
}
