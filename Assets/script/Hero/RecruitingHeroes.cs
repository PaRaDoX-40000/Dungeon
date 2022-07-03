using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitingHeroes : MonoBehaviour
{
    [SerializeField] private DataBase dataBase;
    [SerializeField] private HeroPanel[] heroPanel;
    [SerializeField] private ImprovementMaximBeds improvementMaximBeds;
    [SerializeField] private HeroesDetailedMenu detailedMenu;
    private Hero targetHero;

    internal void ShoweDetailedHero(Hero hero)
    {
        targetHero = hero;
        detailedMenu.ShoweDetailedHero(hero);
    }
     

    public void ChangeHeroes()
    {
       
        for (int i = 0; i < dataBase.ProposedHeroes.Count; i++)
        {
            heroPanel[i].Init(dataBase.ProposedHeroes[i]);                      
        }
        for (int i = dataBase.ProposedHeroes.Count; i < heroPanel.Length; i++)
        {
            heroPanel[i].gameObject.SetActive(false);
        }
    }
    
    void OnEnable()
    {
        ChangeHeroes();
    }

    public void Recruit()
    {
        if(improvementMaximBeds.MaximBeds< dataBase.freeHero.Count && targetHero!=null)
        {
            dataBase.AddHero(targetHero);
            dataBase.ProposedHeroes.Remove(targetHero);
            targetHero = null;
            detailedMenu.ShoweEmpty();
            ChangeHeroes();
        }
        
    }

}
