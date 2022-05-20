using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GetHealingIvidual", menuName = "Peculiarities/Distribution/GetHealingIvidual", order = 51)]
public class GetHealingIvidual : Distribution
{
    public override void Subscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        heroPeculiarity.Hero.GetHealing += heroPeculiarity.Peculiarity.Effect.effect;
    }

    public override void Unsubscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity)
    {
        heroPeculiarity.Hero.GetHealing -= heroPeculiarity.Peculiarity.Effect.effect;
    }
}
