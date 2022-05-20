using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoneSkin", menuName = "Peculiarities/Effect/StoneSkin", order = 51)]
public class EffectStoneSkin : Effect
{
    [SerializeField] int armor;

    public override void effect(Enemy enemy, Hero hero, Fight fight, Adventure adventure)
    {
        Debug.Log("каменая кожа сработала: заблокировано " + (int)(enemy.Stats[2] * ((float)armor / 100f)));
        hero.Stats[0] += (int)(enemy.Stats[2] * ((float)armor / 100f));

    }

    public override void effect(Loot loot, Adventure adventure)
    {
        
    }  
    public override void effect(int amountHeal, Hero hero, Fight fight)
    {
       
    }
    public override void effect(Damage damage, Enemy enemy, Hero hero, Fight fight)
    {

    }
}
