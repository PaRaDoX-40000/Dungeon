using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroEquipmentSlot
{
    private Equipable equipable = null;
    private int EquippedType;
    private bool equipped = false;

    public HeroEquipmentSlot(int type)
    {
        EquippedType = type;
    }

    public bool Equipped => equipped;

    public Equipable Equipable  => equipable; 

    public void Equip(Equipable equipable, DataBase dataBase, ref int[] stats)
    {
        bool same = false;
        if (this.Equipable == equipable)
        {
            same = true;
        }
        if (equipped == true)
        {
            DesEquip(dataBase, ref stats);
        }
        if (same == false)
        {
            this.equipable = equipable;
            foreach (StatsApp statsAp in equipable.StatsApp)
            {
                stats[(int)statsAp.Stat] += statsAp.Value;
            }
            equipable.Equip();
            dataBase.TruRemoveEquipable(equipable);
            equipped = true;
        }


    }
    void DesEquip(DataBase dataBase, ref int[] stats)
    {
        foreach (StatsApp statsAp in Equipable.StatsApp)
        {
            stats[(int)statsAp.Stat] -= statsAp.Value;
        }
        Equipable.DesEquip();
        dataBase.AddEquipable(Equipable);
        equipped = false;
        equipable = null;
    }
}

