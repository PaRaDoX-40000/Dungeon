using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitingHeroes : MonoBehaviour
{
    [SerializeField] CommonHeir commonHeir;
    [SerializeField] HeroPanel[] heroPanel;
    
    public void ChangeHeroes()
    {
       
        for (int i = 0; i < commonHeir.dataBase.ProposedHeroes.Count; i++)
        {
            
            //heroPanel[i].HP.text = commonHeir.dataBase.ProposedHeroes[i].stats[0].ToString();
            //heroPanel[i].Ataca.text = commonHeir.dataBase.ProposedHeroes[i].stats[1].ToString();
            //heroPanel[i].Spude.text = commonHeir.dataBase.ProposedHeroes[i].stats[2].ToString();
            //heroPanel[i].aicon.sprite = commonHeir.dataBase.ProposedHeroes[i].icon;
            //heroPanel[i].hero = commonHeir.dataBase.ProposedHeroes[i];
            //heroPanel[i].gameObject.SetActive(true);
        }
        for (int i = commonHeir.dataBase.ProposedHeroes.Count; i < heroPanel.Length; i++)
        {
            heroPanel[i].gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        ChangeHeroes();

    }
    void OnEnable()
    {
        ChangeHeroes();
    }

    public void Recruit()
    {
        //commonHeir.dataBase.hero.Add(commonHeir.RecruitingDetailedMenu.targetHero);
        //commonHeir.dataBase.ProposedHeroes.Remove(commonHeir.RecruitingDetailedMenu.targetHero);
        //commonHeir.RecruitingDetailedMenu.targetHero = null;
        //commonHeir.RecruitingDetailedMenu.gameObject.SetActive(false);
        //ChangeHeroes();
    }

}
