using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImproveSaveData
{
    public List<int> improvementsHubLevels;
    public List<int> improvementsForgeLevels;
    public List<int> improvementsLaboratoryLevels;
    public List<int> improvementsBarracksLevels;
    public List<int> improvementsTradeLevels;

    
    public void Save(ImprovementCollection collection)
    {

        ProcessElement(ref improvementsHubLevels, collection.ImprovementsHub);
        ProcessElement(ref improvementsForgeLevels, collection.ImprovementsForge);
        ProcessElement(ref improvementsLaboratoryLevels, collection.ImprovementsLaboratory);
        ProcessElement(ref improvementsBarracksLevels, collection.ImprovementsBarracks);
        ProcessElement(ref improvementsTradeLevels, collection.ImprovementsTrade);
    }
    private void ProcessElement(ref List<int> levels, Improvement[] improvements)
    {
        foreach (Improvement improvement in improvements)
        {
            levels.Add(improvement.level);
        }
    }
    public List<List<int>> Loading()
    {
        List<List<int>> returnLevels = new List<List<int>>() { improvementsHubLevels, improvementsForgeLevels, improvementsTradeLevels, improvementsLaboratoryLevels, improvementsBarracksLevels };
        return returnLevels;
    }



}
