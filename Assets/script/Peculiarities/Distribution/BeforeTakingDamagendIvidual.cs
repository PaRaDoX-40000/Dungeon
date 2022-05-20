using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BeforeTakingDamagendIvidual", menuName = "Peculiarities/Distribution/BeforeTakingDamagendIvidual", order = 51)]
public class BeforeTakingDamagendIvidual : Distribution
{
    public override void Subscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        heroPeculiarity.Hero.BeforeTakingDamage += heroPeculiarity.Peculiarity.Effect.effect;      
    }

    public override void Unsubscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        heroPeculiarity.Hero.BeforeTakingDamage -= heroPeculiarity.Peculiarity.Effect.effect;
    }
}
