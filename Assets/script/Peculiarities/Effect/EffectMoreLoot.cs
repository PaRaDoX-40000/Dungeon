using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectMoreLoot", menuName = "Peculiarities/Effect/EffectMoreLoot", order = 51)]
public class EffectMoreLoot : Effect
{
    int number = 0;

    

    public override void effect(Loot loot, Adventure adventure)
    {
        if (number >= 3)
        {
            adventure.AddLootEnemy(new List<Loot> { loot });
            number = -1;
            Debug.Log("Crabotolo effect");
        }
        number++;
    }

    
    public override void effect(int amountHeal, Hero hero, Fight fight)
    {

    }
    public override void effect(Enemy enemy, Hero hero, Fight fight, Adventure adventure)
    {

    }
    public override void effect(Damage damage, Enemy enemy, Hero hero, Fight fight)
    {

    }
}
    

