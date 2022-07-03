using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImproveSaveData
{
    public List<int> improvementsLevels;
   

    
    public void Save(ImprovementCollection collection)
    {
        ProcessElement(ref improvementsLevels, collection.Improvements);        
    }
    private void ProcessElement(ref List<int> levels, Improvement[] improvements)
    {
        foreach (Improvement improvement in improvements)
        {
            //levels.Add(improvement.level);
        }
    }
    public List<int> Loading()
    {        
        return improvementsLevels;
    }



}
