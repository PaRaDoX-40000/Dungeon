using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImprovementCollection : MonoBehaviour
{
    private ImproveSaveData saveData;

    [SerializeField] private Improvement[] improvements;
    private string path;
   
    public Improvement[] Improvements => improvements; 
   

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
            List<int> Levels = saveData.Loading();

            ProcessElement(Levels, improvements);
            
        }
    }
    private void ProcessElement(List<int> levels, Improvement[] improvements)
    {
        for (int i =0;i< improvements.Length;i++)
        {
            //improvements[i].level = levels[i];
        }
    }
}
