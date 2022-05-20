using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectСontainer
{
    private Coroutine coroutineEffect;
    //Hero hero;
    private StatusEffect statusEffect;

    public Coroutine CoroutineEffect => coroutineEffect;
    public StatusEffect StatusEffect => statusEffect;

    public StatusEffectСontainer( StatusEffect statusEffect)
    {
        
        //this.hero = hero;
        this.statusEffect = statusEffect;
    }
    public void SetCoroutine(Coroutine coroutine)
    {
        coroutineEffect = coroutine;
    }

    public void ForceRemoveStatus(Hero hero)
    {
        
        statusEffect.RemoveStatus(hero);
        RemoveStatus(hero);
    }


    public void RemoveStatus(Hero hero)
    {
        hero.statusEffectСontainer.Remove(this);
    }

}
