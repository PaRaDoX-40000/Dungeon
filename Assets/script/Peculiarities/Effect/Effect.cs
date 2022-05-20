using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public List<Hero> heroes;

    public abstract void effect(Enemy enemy, Hero hero, Fight fight, Adventure adventure);
    public abstract void effect(Loot loot, Adventure adventure);
    public abstract void effect(int amountHeal, Hero hero, Fight fight);
    public abstract void effect(Damage damage, Enemy enemy, Hero hero, Fight fight);



}
