using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CraftEquipable : MonoBehaviour
{  
    [SerializeField] private LootAmountChangerPanel[] lootAmountChangerPanels; 
    [SerializeField] private CraftEquipablePanelUI CraftEquipablePanelUI;
    [SerializeField] DataBase dataBase;
    [SerializeField] CraftMiniGame craftMiniGame;
    private int gold = 100;
    private List<Loot> loots = new List<Loot>();
    private bool craftFull;
    private Sprite iconEquipable;
    private int maxLoots = 5;


    public UnityAction<bool> ReachedMaximumLoots;

    private EquipableClass equipableClass;
    private List<StatsApp> debuffs = new List<StatsApp>();
    int numberImprovements = 0;


    public void ShowCraftMenu(EquipableClassCraft classCraft)
    {
        ClearCraft();

        equipableClass = classCraft.EquipableClass;
        debuffs.AddRange(classCraft.Debuffs);
        iconEquipable = classCraft.ImageIcon.sprite;
        CraftEquipablePanelUI.Init(iconEquipable, classCraft.PermissibleStats,gold);
        
    }

    public void ShowLoot(int stat)
    {              
        Dictionary<Loot, int> dataBaseLoots = dataBase.loots;
        Dictionary<Loot, int>.KeyCollection lootsKey = dataBaseLoots.Keys;
        int counter = 0;
        foreach(Loot loot in lootsKey.Where(loot=> (int)loot.StatsApp.Stat== stat))
        {
            lootAmountChangerPanels[counter].Init(loot, dataBaseLoots[loot], CountInLoot(loot), craftFull);
            counter++;
        }        
        for(int i = counter;i< lootAmountChangerPanels.Length; i++)
        {
            lootAmountChangerPanels[i].gameObject.SetActive(false);
        }
    }

    private int CountInLoot(Loot loot)
    {
        
        return loots.Where(l => l == loot).Count();
    }
     

    public void AddLoot(Loot loot)
    {
        loots.Add(loot);                     
        if (loots.Count == maxLoots)
        {
            craftFull = true;
            ReachedMaximumLoots.Invoke(craftFull);        
        }
        СalculateGold(loot, true);


    }
    
    public void RemoveLoot(Loot loot)
    {                             
        loots.Remove(loot);
        if (craftFull == true)
        {
            craftFull = false;
            ReachedMaximumLoots.Invoke(craftFull);
        }
        СalculateGold(loot, false);
    }

    private void СanСreate()
    {             
        CraftEquipablePanelUI.SetActiveButtonCraft(numberImprovements > 0 && dataBase.gold > gold);             
    }



    //public void StartMiniGame()
    // {
    //     Debug.Log(loots.Count);
    //     Debug.Log(commonHeir.dataBase.gold);

    //     if (loots.Count > 0 && gold<commonHeir.dataBase.gold)
    //     {




    //         craftMiniGame.gameObject.SetActive(true);
    //         craftMiniGame.StartMiniGame(D);
    //     }

    // }

    public void Сreate(/*int time*/)
    {
       
        foreach (Loot i in loots)
        {
            debuffs.Add(i.StatsApp);
        }
        Equipable equipable = new Equipable( debuffs, equipableClass, iconEquipable/*, time*/);
        dataBase.AddEquipable(equipable);
        dataBase.TryRemoveLoots(loots);
        dataBase.TryСhangeGold(-gold);
        ClearCraft();
    }
    private void ClearCraft()
    {
        loots.Clear();
        debuffs.Clear();
        gold = 100;
        numberImprovements = 0;
        craftFull = false;

        foreach (LootAmountChangerPanel lootAmountChangerPanel in lootAmountChangerPanels)
        {
            lootAmountChangerPanel.gameObject.SetActive(false);
        }
        CraftEquipablePanelUI.Clear();
    }

    
    private void СalculateGold(Loot loot, bool add)
    {
        if (add)
        {
            for (int i = 0; i < loot.StatsApp.Value; i++)
            {
                numberImprovements++;
                gold += 100 * numberImprovements;
            }
        }
        else
        {
            for (int i = 0; i < loot.StatsApp.Value; i++)
            {
                gold -= 100 * numberImprovements;
                numberImprovements--;
            }
        }
        СanСreate();
        CraftEquipablePanelUI.changeGold(gold);
    }
}
