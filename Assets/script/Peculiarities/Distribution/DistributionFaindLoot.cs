using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FaindLoot", menuName = "Peculiarities/Distribution/FaindLoot", order = 51)]
public class DistributionFaindLoot : Distribution
{
     
    public override void Subscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        adventure.FaindLootEvent += heroPeculiarity.Peculiarity.Effect.effect;
    }

    public override void Unsubscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        adventure.FaindLootEvent -= heroPeculiarity.Peculiarity.Effect.effect;
    }
}
