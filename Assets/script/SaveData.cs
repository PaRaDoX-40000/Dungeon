using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] CommonHeir commonHeir;
    private string path;

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (File.Exists(path))
        {
            
            commonHeir.dataBase = JsonUtility.FromJson<DataBase>(File.ReadAllText(path));
            commonHeir.dataBase.Loading();

        }
    }
    void OnApplicationQuit()
    {
        
        commonHeir.dataBase.Save();
        File.WriteAllText(path, JsonUtility.ToJson(commonHeir.dataBase));
        
    }

    

}
