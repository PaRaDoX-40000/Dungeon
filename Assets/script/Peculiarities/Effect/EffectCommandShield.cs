using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommandShield", menuName = "Peculiarities/Effect/CommandShield", order = 51)]

public class EffectCommandShield : Effect
{
   [SerializeField] int armor;

    public override void effect(Damage damage, Enemy enemy, Hero hero, Fight fight)
    {
        
        if (!heroes.Contains(hero))
        {
           
            foreach (Hero forHero in fight.Heroes)
            {
                
                if (heroes.Contains(forHero))
                {
                    Debug.Log("CommandShield сработала: заблокировано " + (int)(damage.GetDamage * ((float)armor / 100f)));
                    Debug.Log("урон был " + damage.GetDamage);
                    forHero.ChangeHealth(-(int)(damage.GetDamage * ((float)armor / 100f)));
                    damage.ChangeDamage(-(int)(damage.GetDamage * ((float)armor / 100f)));
                    Debug.Log("урон стал " + damage.GetDamage);
                    break;
                }
               
            }
            
        }
    }
    public override void effect(Enemy enemy, Hero hero, Fight fight, Adventure adventure)
    {
        
    }

    public override void effect(Loot loot, Adventure adventure)
    {
    }

    

    public override void effect(int amountHeal, Hero hero, Fight fight)
    {
    }

}
