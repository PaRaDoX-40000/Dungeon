using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageModifier", menuName = "Peculiarities/Distribution/DamageModifier", order = 51)]
public class DamageModifier : Distribution
{
    public override void Subscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        foreach(Hero adventureHero in adventure.Heroes)
        {
            adventureHero.TakenDamageModifier+= heroPeculiarity.Peculiarity.Effect.effect;
        }       
        heroPeculiarity.Peculiarity.Effect.heroes.Add(heroPeculiarity.Hero);
    }

    public override void Unsubscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        foreach (Hero adventureHero in fight.Heroes)
        {
            adventureHero.TakenDamageModifier -= heroPeculiarity.Peculiarity.Effect.effect;
        }
        heroPeculiarity.Peculiarity.Effect.heroes.Remove(heroPeculiarity.Hero);
    }
}
