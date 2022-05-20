using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    public Hero hero;
    public InventoryEquipmentPanel inventory;

    void Start()
    {
        //Equip(inventory.inventory[0], ref hero.Weapon);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Equip(Equipable equip, ref Equipable equipped)
    {
        if (equipped != null)
        {
            DesEquip(equipped);
        }

        for(int i=0; i < equip.StatsApp.Count; i++)
        {
            hero.Stats[(int)equip.StatsApp[i].Stat] += equip.StatsApp[i].Value;
        }
        equipped = equip;
    }
    void DesEquip(Equipable a)
    {
        for (int i = 0; i < a.StatsApp.Count; i++)
        {
            hero.Stats[(int)a.StatsApp[i].Stat] -= a.StatsApp[i].Value;
        }
       
    }
}
