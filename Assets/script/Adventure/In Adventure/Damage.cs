using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damage
{
    private int damage;

    public int GetDamage => damage;

    public void ChangeDamage(int amount)
    {
        damage += amount;
        if (damage < 0)
        {
            damage = 0;
        }
    }
    public Damage(int D)
    {
        damage = D;
    }
}
