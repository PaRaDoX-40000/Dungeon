using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHeir : MonoBehaviour
{
    
    
   
   
    [SerializeField] public DataBase dataBase;
    [SerializeField] public HeroClasses heroClasses;
    [SerializeField] public HeroesDetailedMenu RecruitingDetailedMenu;    
    [SerializeField] private PeculiaritiesCollection PeculiaritiesCollection;

    [SerializeField] private List<Consumable> consumable = new List<Consumable>();//TEct Ydoli
    [SerializeField] private List<Loot> loot = new List<Loot>();//TEct Ydoli

    Hero hero;//TEct Ydoli

    private void Awake()
    {
        

        dataBase.hero.Add(new Hero(heroClasses.heroClass[0], PeculiaritiesCollection.PeculiaritiesLIst));
        hero = new Hero(heroClasses.heroClass[1]);
        dataBase.hero.Add(hero);
        dataBase.hero.Add(new Hero(heroClasses.heroClass[2]));
        dataBase.hero.Add(new Hero(heroClasses.heroClass[Random.Range(0, heroClasses.heroClass.Length)]));
        for (int i = 0; i < 10; i++)
        {
            Clik();
            Clik2();
        }


    }

    public void Clik()//TEct Ydoli
    {
        dataBase.AddConsumables(consumable);
    }
    public void Clik2()//TEct Ydoli
    {
        dataBase.AddLoots(loot);
    }
    public void Clik3()//TEct Ydoli
    {
        hero.LevelApp(500);
    }


}
