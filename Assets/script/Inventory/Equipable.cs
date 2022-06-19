using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipable
{
    private Sprite icon;
    private bool equipped = false;
    private EquipableClass equipableClass;
    private List<StatsApp> statsApp = new List<StatsApp>();
    //private UniqueProperty uniqueProperty;

    public Sprite Icon => icon;
    public bool Equipped => equipped;
    public EquipableClass EquipableClass => equipableClass;
    public List<StatsApp> StatsApp=> statsApp;

    public  Equipable( List<StatsApp> loot, EquipableClass equipable, Sprite space/*, int time*/)
    {
        foreach (StatsApp i in loot)
        {          
            if (Repeats((int)i.Stat))
            {               
                foreach (StatsApp j in StatsApp)
                {                
                    if (j.Stat == i.Stat)
                    {                       
                        j.Value += i.Value;
                    }
                }
            }
            else
            {
                StatsApp stats = new StatsApp(i);
                StatsApp.Add(stats);
            }      
        }      
        equipableClass = equipable;
        icon = space;               
            foreach(StatsApp i in StatsApp)
            {
                if (i.Value < 15)
                {
                    i.Value = (int)((float)i.Value * 1.2f);
                }
                if (i.Value > 30)
                {
                    i.Value = (int)((float)i.Value * 0.8f);
                }
            }
    }
    private bool Repeats(int loot)
    {      
        foreach (StatsApp i in StatsApp)
            if ((int)i.Stat == loot)
            {

                return true;
            }
        return false;
    }
    public void Equip()
    {
        equipped = true;
    }
    public void DesEquip()
    {
        equipped = false;
    }

}

