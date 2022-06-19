//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Hero 
{
    private string name;
    [SerializeField] private int[] stats = new int[9];
    //0.Здоровье
    //1.Макс здорове
    //2.Урон
    //3.Скорость 
    //4.Защитаa
    //5.Коэффициент провокации
    //6.Скорость атаки
    //7.Храбрость
    //8.Заметность
    private Level heroLevel;
    private Sprite icon;
    //public float aggression;
    [SerializeField] private List<HeroPeculiarity> heroPeculiarities = new List<HeroPeculiarity>();
   
    private List<StatusEffect> activeStatusEffects = new List<StatusEffect>();

    private bool dead = false;

    public bool Dead => dead;

    

    public bool retreated = false;


   private HeroEquipmentSlot[]  heroEquipmentSlots;
    //private Equipable[] equipment = new Equipable[3];
    

    // 1 Weapon;
    // 2 Armore;
    // 3 Mascot;
    private int clas;


    //public Equipable[] Equipment => equipment;

    public string Name => name;
    public int[] Stats => stats;
    public Sprite Icon => icon;

    public Level HeroLevel => heroLevel;

    public List<HeroPeculiarity> HeroPeculiarities => heroPeculiarities;

    public int Clas => clas;

    public HeroEquipmentSlot[] HeroEquipmentSlots => heroEquipmentSlots;

    public List<StatusEffectСontainer> statusEffectСontainer = new List<StatusEffectСontainer>();
       

    public UnityAction<Enemy, Hero, Fight, Adventure > BeforeTakingDamage;
    public UnityAction<Enemy, Hero, Fight, Adventure> AfterTakingDamage;
    public UnityAction<Damage, Enemy, Hero, Fight> TakenDamageModifier;

    public UnityAction<Enemy, Hero, Fight, Adventure> BeforeDamage;
    public UnityAction<Enemy, Hero, Fight, Adventure> AfterDamage;
    public UnityAction<Damage, Enemy, Hero, Fight> DamageModifier;

    public UnityAction<int, Hero, Fight> GetHealing;
    public UnityAction<Enemy, Hero, Fight, Adventure> Died;





    public Hero(HeroClass heroClass,List<Peculiarity> peculiarities=null)
    {
        Stats[1] = Random.Range(70, 100);
        Stats[0] = Stats[1];
        Stats[2] = Random.Range(7, 15);
        Stats[3] = Random.Range(7, 15);
        Stats[4] = 0;
        Stats[5] = Random.Range(7, 15);
        Stats[6] = Random.Range(7, 15);
        Stats[7] = Random.Range(20, 200);
        Stats[8] = Random.Range(7, 15);

        //level = 1;
        heroEquipmentSlots = new HeroEquipmentSlot[3] {new HeroEquipmentSlot(0), new HeroEquipmentSlot(1),new HeroEquipmentSlot(2) };
        heroLevel = new Level(Stats);
        

        clas = heroClass.Clas;
        icon = heroClass.Sprite[Random.Range(0, heroClass.Sprite.Length)];
        name = heroClass.Names[Random.Range(0, heroClass.Names.Length)];
        if (peculiarities!=null)
        foreach(Peculiarity peculiarity in peculiarities)
        {
            heroPeculiarities.Add(new HeroPeculiarity(this, peculiarity));
        }

    }


    public void DoHit(Enemy enemy, Fight fight, Adventure adventure)
    {      
        if (!dead && !retreated)
        {
            BeforeDamage?.Invoke(enemy, this, fight, adventure);
            Damage damage = new Damage(Stats[2]);
            DamageModifier?.Invoke(damage, enemy, this, fight);
            bool enemyDead = enemy.GetDamage(damage.GetDamage);
            if (enemyDead == true)
            {
                heroLevel.AddExperiencePoints(enemy.ExperiencePoints, this, ref stats);
            }
            AfterDamage?.Invoke(enemy, this, fight, adventure);
        }
    }

    public void ChangeHealth(int amount)
    {
        

        Stats[0] += amount;
        if (Stats[0] > Stats[1])
            Stats[0] = Stats[1];
        if (Stats[0] < 0)
            Stats[0] = 1;
    }

    public void TakeDamage(int damage, Enemy enemy, Fight fight, Adventure adventure)
    {
        Damage damageModifier = new Damage(damage);
        BeforeTakingDamage?.Invoke(enemy, this, fight, adventure);
        TakenDamageModifier?.Invoke(damageModifier, enemy,this, fight);

        damage = damageModifier.GetDamage - Stats[4];
        if (damage < 0)
        {
            damage = 0;
        }
        Stats[0] -= damage;
        if (Stats[0] < 0)
        {
            dead = true;
            Died?.Invoke(enemy,this,fight,adventure);
        }
        if(dead == true)
        {
            foreach(HeroPeculiarity heroPeculiarity in heroPeculiarities)
            {               
                heroPeculiarity.Peculiarity.Distribution.Unsubscribe(fight, adventure, this, heroPeculiarity);
            }
        }

        
        AfterTakingDamage?.Invoke(enemy, this, fight, adventure);
    }
    public void TakeDamageWithoutArmor(int damage)
    {
        Stats[0] -= damage;
        if (Stats[0] < 0)
        {
            dead = true;
        }
    }
    public void TryRetreat(Enemy enemy)
    {
        float heroChance = Random.Range(0f, 1f);
        float enemieChance = Random.Range(0f, 1f);
        if(Stats[3]* heroChance> enemy.Stats[4]* enemieChance)
        {        
            retreated = true;
        }      
    }
    public void Heal(int amount)
    {      
        Stats[0] += amount;
        if (Stats[0] > Stats[1])
            Stats[0] = Stats[1];
    }
    public void Equip(Equipable equipable,DataBase dataBase)
    {
        HeroEquipmentSlots[(int)equipable.EquipableClass.equippableSlot].Equip(equipable, dataBase, ref stats);       
    }
    

    public void LevelApp(int amunt)
    {
        heroLevel.AddExperiencePoints(amunt, this, ref stats);
    }
    

}
