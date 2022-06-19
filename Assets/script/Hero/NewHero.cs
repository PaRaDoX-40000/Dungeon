using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHero : MonoBehaviour
{
   
    [SerializeField] private DataBase dataBase;
    [SerializeField] private HeroClasses heroClasses;
    [SerializeField] private PeculiaritiesCollection PeculiaritiesCollection;

    void UpgradeNewHeroes(int amount)
    {
        dataBase.ProposedHeroes.Clear();
        for (int i=0; i < amount; i++)
        {
            dataBase.ProposedHeroes.Add(new Hero(heroClasses.heroClass[Random.Range(0, heroClasses.heroClass.Length)]));
        }
    }

    private void Start()
    {
        UpgradeNewHeroes(5);
        dataBase.hero.Add(new Hero(heroClasses.heroClass[0], PeculiaritiesCollection.PeculiaritiesLIst));
        
        dataBase.hero.Add(new Hero(heroClasses.heroClass[1]));
        dataBase.hero.Add(new Hero(heroClasses.heroClass[2]));
        dataBase.hero.Add(new Hero(heroClasses.heroClass[Random.Range(0, heroClasses.heroClass.Length)]));
    }


}
