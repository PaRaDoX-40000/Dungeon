using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitingHeroes : MonoBehaviour
{
    [SerializeField] DataBase dataBase;
    [SerializeField] HeroPanel[] heroPanel;
    
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
        //dataBase.hero.Add(commonHeir.RecruitingDetailedMenu.targetHero);
        //commonHeir.dataBase.ProposedHeroes.Remove(commonHeir.RecruitingDetailedMenu.targetHero);
        //commonHeir.RecruitingDetailedMenu.targetHero = null;
        //commonHeir.RecruitingDetailedMenu.gameObject.SetActive(false);
        //ChangeHeroes();
    }

}
