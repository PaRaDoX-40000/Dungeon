using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Distribution : ScriptableObject
{
    public abstract void Subscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity);
    public abstract void Unsubscribe(Fight fight, Adventure adventure, Hero hero, HeroPeculiarity heroPeculiarity);
}
