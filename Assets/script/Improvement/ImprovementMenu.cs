using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovementMenu : MonoBehaviour
{

    [SerializeField] private ImprovementPanel[] improvementPanel;
    [SerializeField] private ImprovementCollection improvementCollection;
    [SerializeField] DataBase dataBase;



    void ShowImprovements(Improvement[] improvements )
    {
        for(int i=0; i< improvements.Length; i++)
        {
            improvementPanel[i].Init(improvements[i], dataBase);           
        }
        for(int i = improvements.Length; i< improvementPanel.Length; i++)
        {
            improvementPanel[i].gameObject.SetActive(false);
        }        
    }

    public void ChooseImprovement(int number)
    {
        switch (number)
        {
            case 1:
                ShowImprovements(improvementCollection.ImprovementsHub);
                break;

            case 2:
                ShowImprovements(improvementCollection.ImprovementsForge);
                break;

            case 3:
                ShowImprovements(improvementCollection.ImprovementsLaboratory);
                break;
            case 4:
                ShowImprovements(improvementCollection.ImprovementsBarracks);
                break;
            case 5:
                ShowImprovements(improvementCollection.ImprovementsTrade);
                break;
        }
    }


}

