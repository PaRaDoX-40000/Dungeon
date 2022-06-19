using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseSaver : MonoBehaviour
{
    
    
   
   
    [SerializeField] private DataBase dataBase;
    

    [SerializeField] private List<Consumable> consumable = new List<Consumable>();//TEct Ydoli
    [SerializeField] private List<Loot> loot = new List<Loot>();//TEct Ydoli

   

    private void Awake()
    {


       
        for (int i = 0; i < 10; i++)
        {
            Clik();
            Clik2();
        }


    }

    public void Clik()//TEct Ydoli
    {
        dataBase.AddConsumables(consumable);
    }
    public void Clik2()//TEct Ydoli
    {
        dataBase.AddLoots(loot);
    }
    public void Clik3()//TEct Ydoli
    {
        
    }


}
