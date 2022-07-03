using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ImprovementMenu : MonoBehaviour
{

    [SerializeField] private ImprovementPanel[] improvementPanel;
    [SerializeField] private ImprovementCollection improvementCollection;
    [SerializeField] DataBase dataBase;



    void ShowImprovements(List<Improvement> improvements )
    {
        for(int i=0; i< improvements.Count; i++)
        {
            improvementPanel[i].Init(improvements[i], dataBase);           
        }
        for(int i = improvements.Count; i< improvementPanel.Length; i++)
        {
            improvementPanel[i].gameObject.SetActive(false);
        }        
    }

    public void ChooseImprovement(int number)
    {
        ShowImprovements(improvementCollection.Improvements.Where(q => (int)q.NameImprovedStructure == number).ToList());
    }


}

