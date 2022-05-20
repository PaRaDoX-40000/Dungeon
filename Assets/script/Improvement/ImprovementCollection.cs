using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImprovementCollection : MonoBehaviour
{
    private ImproveSaveData saveData;

    [SerializeField] private Improvement[] improvementsHub;
    [SerializeField] private Improvement[] improvementsForge;
    [SerializeField] private Improvement[] improvementsLaboratory;
    [SerializeField] private Improvement[] improvementsBarracks;
    [SerializeField] private Improvement[] improvementsTrade;

    public Improvement[] ImprovementsHub  => improvementsHub; 
    public Improvement[] ImprovementsForge => improvementsForge; 
    public Improvement[] ImprovementsLaboratory => improvementsLaboratory; 
    public Improvement[] ImprovementsBarracks => improvementsBarracks; 
    public Improvement[] ImprovementsTrade => improvementsTrade;

    private string path;

    public void Awake()
    {
        path = Path.Combine(Application.dataPath, "ImprovementSave.json");
        //Test5.Save += Sale;
        //Test5.Loade += Lode;
    }

    public void Save()
    {
        saveData.Save(this);
        File.WriteAllText(path, JsonUtility.ToJson(saveData));
    }
    public void Loading()
    {
        if (File.Exists(path))
        {

            saveData = JsonUtility.FromJson<ImproveSaveData>(File.ReadAllText(path));
            List<List<int>> Levels = saveData.Loading();

            ProcessElement(Levels[0], improvementsHub);
            ProcessElement(Levels[1], improvementsForge);
            ProcessElement(Levels[2], improvementsLaboratory);
            ProcessElement(Levels[3], improvementsBarracks);
            ProcessElement(Levels[4], improvementsTrade);
        }
    }
    private void ProcessElement(List<int> levels, Improvement[] improvements)
    {
        for (int i =0;i< improvements.Length;i++)
        {
            improvements[i].level = levels[i];
        }
    }
}
