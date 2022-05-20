using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHero : MonoBehaviour
{
    public CommonHeir commonHeir;

   void UpgradeNewHeroes(int amount)
    {
        commonHeir.dataBase.ProposedHeroes.Clear();
        for (int i=0; i < amount; i++)
        {
            commonHeir.dataBase.ProposedHeroes.Add(new Hero(commonHeir.heroClasses.heroClass[Random.Range(0, commonHeir.heroClasses.heroClass.Length)]));
        }
    }

    private void Start()
    {
        UpgradeNewHeroes(5);
    }


}
