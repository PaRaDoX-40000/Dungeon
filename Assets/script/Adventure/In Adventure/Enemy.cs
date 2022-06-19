using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    //0.Здоровье
    //1.Макс здорове
    //2.Урон    
    //3.Защитаa    
    //4.Скорость атаки 
    //5.Внимательность 
    public int[] Stats = new int[6];
    private bool dead = false;
    [SerializeField] private RarityLoot[] rarityLoots;
    [SerializeField] private Sprite icon;
    [SerializeField] private int experiencePoints;
    [SerializeField] private StatusEffectСhance statusEffectСhance;

    public Sprite Icon => icon;

    public bool Dead => dead;
    public RarityLoot[] RarityLoots => rarityLoots;

    public StatusEffectСhance StatusEffectСhance => statusEffectСhance;

    public int ExperiencePoints => experiencePoints;

    public bool GetDamage(int damage)
    {
        damage -= Stats[3];
        if (damage < 0)
        {
            damage = 0;
        }
        Stats[0] -= damage;
        if (Stats[0] < 0)
        {
            dead = true;

        }
        return dead;
    }

    public void DoHit(Hero hero, Fight fight, Adventure adventure)
    {
        if (!dead && hero!=null)
        {
           
            hero.TakeDamage(Stats[2], this, fight, adventure);
            Debug.Log("удар " + this.name + " по герою " + " здороая осталась " + hero.Stats[0]);

        }
    }
}
